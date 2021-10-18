#pragma once
#include <libyuv.h>

public enum class FourCC
{
	// 10 Primary YUV formats: 5 planar, 2 biplanar, 2 packed.
	FOURCC_I420 = libyuv::FOURCC_I420,
	FOURCC_I422 = libyuv::FOURCC_I422,
	FOURCC_I444 = libyuv::FOURCC_I444,
	FOURCC_I400 = libyuv::FOURCC_I400,
	FOURCC_NV21 = libyuv::FOURCC_NV21,
	FOURCC_NV12 = libyuv::FOURCC_NV12,
	FOURCC_YUY2 = libyuv::FOURCC_YUY2,
	FOURCC_UYVY = libyuv::FOURCC_UYVY,
	FOURCC_I010 = libyuv::FOURCC_I010,  // bt.601 10 bit 420
	FOURCC_I210 = libyuv::FOURCC_I210,  // bt.601 10 bit 422

	// 1 Secondary YUV format: row biplanar.  deprecated.
	FOURCC_M420 = libyuv::FOURCC_M420,

	// 13 Primary RGB formats: 4 32 bpp, 2 24 bpp, 3 16 bpp, 1 10 bpc 2 64 bpp
	FOURCC_ARGB = libyuv::FOURCC_ARGB,
	FOURCC_BGRA = libyuv::FOURCC_BGRA,
	FOURCC_ABGR = libyuv::FOURCC_ABGR,
	FOURCC_AR30 = libyuv::FOURCC_AR30,  // 10 bit per channel. 2101010.
	FOURCC_AB30 = libyuv::FOURCC_AB30,  // ABGR version of 10 bit
	FOURCC_AR64 = libyuv::FOURCC_AR64,  // 16 bit per channel.
	FOURCC_AB64 = libyuv::FOURCC_AB64,  // ABGR version of 16 bit
	FOURCC_24BG = libyuv::FOURCC_24BG,
	FOURCC_RAW = libyuv::FOURCC_RAW,
	FOURCC_RGBA = libyuv::FOURCC_RGBA,
	FOURCC_RGBP = libyuv::FOURCC_RGBP,  // rgb565 LE.
	FOURCC_RGBO = libyuv::FOURCC_RGBO,  // argb1555 LE.
	FOURCC_R444 = libyuv::FOURCC_R444,  // argb4444 LE.

	// 1 Primary Compressed YUV format.
	FOURCC_MJPG = libyuv::FOURCC_MJPG,

	// 14 Auxiliary YUV variations: 3 with U and V planes are swapped, 1 Alias.
	FOURCC_YV12 = libyuv::FOURCC_YV12,
	FOURCC_YV16 = libyuv::FOURCC_YV16,
	FOURCC_YV24 = libyuv::FOURCC_YV24,
	FOURCC_YU12 = libyuv::FOURCC_YU12,  // Linux version of I420.
	FOURCC_J420 = libyuv::FOURCC_J420,  // jpeg (bt.601 full), unofficial fourcc
	FOURCC_J422 = libyuv::FOURCC_J422,  // jpeg (bt.601 full), unofficial fourcc
	FOURCC_J444 = libyuv::FOURCC_J444,  // jpeg (bt.601 full), unofficial fourcc
	FOURCC_J400 = libyuv::FOURCC_J400,  // jpeg (bt.601 full), unofficial fourcc
	FOURCC_F420 = libyuv::FOURCC_F420,  // bt.709 full, unofficial fourcc
	FOURCC_F422 = libyuv::FOURCC_F422,  // bt.709 full, unofficial fourcc
	FOURCC_F444 = libyuv::FOURCC_F444,  // bt.709 full, unofficial fourcc
	FOURCC_H420 = libyuv::FOURCC_H420,  // bt.709, unofficial fourcc
	FOURCC_H422 = libyuv::FOURCC_H422,  // bt.709, unofficial fourcc
	FOURCC_H444 = libyuv::FOURCC_H444,  // bt.709, unofficial fourcc
	FOURCC_U420 = libyuv::FOURCC_U420,  // bt.2020, unofficial fourcc
	FOURCC_U422 = libyuv::FOURCC_U422,  // bt.2020, unofficial fourcc
	FOURCC_U444 = libyuv::FOURCC_U444,  // bt.2020, unofficial fourcc
	FOURCC_F010 = libyuv::FOURCC_F010,  // bt.709 full range 10 bit 420
	FOURCC_H010 = libyuv::FOURCC_H010,  // bt.709 10 bit 420
	FOURCC_U010 = libyuv::FOURCC_U010,  // bt.2020 10 bit 420
	FOURCC_F210 = libyuv::FOURCC_F210,  // bt.709 full range 10 bit 422
	FOURCC_H210 = libyuv::FOURCC_H210,  // bt.709 10 bit 422
	FOURCC_U210 = libyuv::FOURCC_U210,  // bt.2020 10 bit 422
	FOURCC_P010 = libyuv::FOURCC_P010,
	FOURCC_P210 = libyuv::FOURCC_P210,

	// 14 Auxiliary aliases.  CanonicalFourCC() maps these to canonical fourcc.
	FOURCC_IYUV = libyuv::FOURCC_IYUV,  // Alias for I420.
	FOURCC_YU16 = libyuv::FOURCC_YU16,  // Alias for I422.
	FOURCC_YU24 = libyuv::FOURCC_YU24,  // Alias for I444.
	FOURCC_YUYV = libyuv::FOURCC_YUYV,  // Alias for YUY2.
	FOURCC_YUVS = libyuv::FOURCC_YUVS,  // Alias for YUY2 on Mac.
	FOURCC_HDYC = libyuv::FOURCC_HDYC,  // Alias for UYVY.
	FOURCC_2VUY = libyuv::FOURCC_2VUY,  // Alias for UYVY on Mac.
	FOURCC_JPEG = libyuv::FOURCC_JPEG,  // Alias for MJPG.
	FOURCC_DMB1 = libyuv::FOURCC_DMB1,  // Alias for MJPG on Mac.
	FOURCC_BA81 = libyuv::FOURCC_BA81,  // Alias for BGGR.
	FOURCC_RGB3 = libyuv::FOURCC_RGB3,  // Alias for RAW.
	FOURCC_BGR3 = libyuv::FOURCC_BGR3,  // Alias for 24BG.
	FOURCC_CM32 = libyuv::FOURCC_CM32,  // Alias for BGRA kCMPixelFormat_32ARGB
	FOURCC_CM24 = libyuv::FOURCC_CM24,  // Alias for RAW kCMPixelFormat_24RGB
	FOURCC_L555 = libyuv::FOURCC_L555,  // Alias for RGBO.
	FOURCC_L565 = libyuv::FOURCC_L565,  // Alias for RGBP.
	FOURCC_5551 = libyuv::FOURCC_5551,  // Alias for RGBO.

	// deprecated formats.  Not supported, but defined for backward compatibility.
	FOURCC_I411 = libyuv::FOURCC_I411,
	FOURCC_Q420 = libyuv::FOURCC_Q420,
	FOURCC_RGGB = libyuv::FOURCC_RGGB,
	FOURCC_BGGR = libyuv::FOURCC_BGGR,
	FOURCC_GRBG = libyuv::FOURCC_GRBG,
	FOURCC_GBRG = libyuv::FOURCC_GBRG,
	FOURCC_H264 = libyuv::FOURCC_H264,

	// Match any fourcc.
	FOURCC_ANY = -1,
};

template <class T,class U> T array_conversion(array<U>^ data) {
	pin_ptr<U> arrayPin = &data[0];
	T arr = arrayPin;
	return arr;
}