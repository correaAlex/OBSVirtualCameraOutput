#include "pch.h"

#include "VirtualOutput.h"
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

void VirtualCameraOutput::VirtualOutput::Send(Bitmap^ image) {
	int width = image->Width, height = image->Height;
	if (width < width_ || width > width_ || height < height_ || height > height_) {
		throw gcnew BadImageFormatException("Incorrect image size!");
	}
	System::Drawing::Rectangle^ bmpArea = gcnew System::Drawing::Rectangle(0,0, width, height);
	auto bmpData = image->LockBits(*bmpArea, System::Drawing::Imaging::ImageLockMode::ReadWrite, System::Drawing::Imaging::PixelFormat::Format24bppRgb);
	array<Byte>^ data = gcnew array<Byte>(bmpData->Stride * height);
	System::Runtime::InteropServices::Marshal::Copy(bmpData->Scan0,data,0,data->Length);
	image->UnlockBits(bmpData);
	auto destination = gcnew List<Byte>();
	int leapPoint = width * 2;
	for (int i = 0; i < data->Length; i++) {
		if (width % 2 != 0) {
			if (i == leapPoint) {
				i += 1;
				leapPoint += (width * 2) + 2;
				continue;
			}
		}
		destination->Add(data[i]);
	}
	auto arr = destination->ToArray();
	unsigned char* frame = array_conversion<unsigned char*, unsigned char>(arr);
	uint8_t* f = (uint8_t*)frame;
	vo_->send(f);
}