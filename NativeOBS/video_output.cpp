#include "video_output.h"

namespace core
{
    uint64_t video_output::get_timestamp_ns() {
        if (!have_clockfreq_) {
            QueryPerformanceFrequency(&clock_freq_);
            have_clockfreq_ = true;
        }

        LARGE_INTEGER current_time;
        QueryPerformanceCounter(&current_time);
        double time_val = (double)current_time.QuadPart;
        time_val *= 1000000000.0;
        time_val /= (double)clock_freq_.QuadPart;

        return static_cast<uint64_t>(time_val);
    }

    video_output::video_output(uint32_t width, uint32_t height, uint32_t fps, uint32_t fourcc) {
        fourcc_ = libyuv::CanonicalFourCC(fourcc);
        width_ = width;
        height_ = height;

        uint32_t out_frame_size = nv12_frame_size(width, height);

        switch (fourcc_) {
        case libyuv::FOURCC_RAW:
        case libyuv::FOURCC_24BG:
            // RGB|BGR -> I420 -> NV12
            buffer_tmp_.resize(i420_frame_size(width, height));
            buffer_output_.resize(out_frame_size);
            break;
        case libyuv::FOURCC_J400:
            // GRAY -> BGRA -> NV12
            buffer_tmp_.resize(bgra_frame_size(width, height));
            buffer_output_.resize(out_frame_size);
            break;
        case libyuv::FOURCC_I420:
        case libyuv::FOURCC_YUY2:
        case libyuv::FOURCC_UYVY:
            // I420|YUYV|UYVY -> NV12
            buffer_output_.resize(out_frame_size);
            break;
        case libyuv::FOURCC_NV12:
            break;
        }

        uint64_t interval = (uint64_t)(10000000.0 / fps);
        vq_ = video_queue_create(width, height, interval);
        output_running_ = true;
    }

    void video_output::stop() {
        if (!output_running_) {
            return;
        }
        video_queue_close(vq_);
        output_running_ = false;
    }

    void video_output::send(const uint8_t* frame) {
        if (!output_running_)
            return;

        uint8_t* tmp = buffer_tmp_.data();
        uint8_t* out_frame = buffer_output_.data();

        switch (fourcc_) {
        case libyuv::FOURCC_RAW:
            rgb_to_i420(frame, tmp, width_, height_);
            i420_to_nv12(tmp, out_frame, width_, height_);
            break;
        case libyuv::FOURCC_24BG:
            bgr_to_i420(frame, tmp, width_, height_);
            i420_to_nv12(tmp, out_frame, width_, height_);
            break;
        case libyuv::FOURCC_J400:
            gray_to_bgra(frame, tmp, width_, height_);
            bgra_to_nv12(tmp, out_frame, width_, height_);
            break;
        case libyuv::FOURCC_I420:
            i420_to_nv12(frame, out_frame, width_, height_);
            break;
        case libyuv::FOURCC_NV12:
            out_frame = const_cast<uint8_t*>(frame);
            break;
        case libyuv::FOURCC_YUY2:
            yuyv_to_nv12(frame, out_frame, width_, height_);
            break;
        case libyuv::FOURCC_UYVY:
            uyvy_to_nv12(frame, out_frame, width_, height_);
            break;
        }

        // NV12 has two planes
        uint8_t* y = out_frame;
        uint8_t* uv = out_frame + width_ * height_;

        // One entry per plane
        uint32_t linesize[2] = { width_, width_ / 2 };
        uint8_t* data[2] = { y, uv };

        uint64_t timestamp = get_timestamp_ns();

        video_queue_write(vq_, data, linesize, timestamp);
    }
}