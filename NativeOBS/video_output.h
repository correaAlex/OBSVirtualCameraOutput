#pragma once
#include <stdio.h>
#include <Windows.h>
#include <vector>
#include <string>
#include <functional>
#include <optional>
#include "memory_queue.h"
#include "image_formats.h"

namespace core
{
    class video_output
    {
    private:
        bool output_running_ = false;
        video_queue_t* vq_;
        uint32_t width_;
        uint32_t height_;
        uint32_t fps_;
        uint32_t fourcc_;
        std::vector<uint8_t> buffer_tmp_;
        std::vector<uint8_t> buffer_output_;
        bool have_clockfreq_ = false;
        LARGE_INTEGER clock_freq_;

        uint64_t get_timestamp_ns();

    public:
        video_output(uint32_t width, uint32_t height, uint32_t fps, uint32_t fourcc);
        void stop();
        bool is_running() { return output_running_; };
        void send(const uint8_t* frame);
    };
}

