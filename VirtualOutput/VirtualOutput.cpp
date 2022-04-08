#include "pch.h"

#include "VirtualOutput.h"
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

void VirtualCameraOutput::VirtualOutput::Send(array<Byte>^ image) {
	auto destination = gcnew List<Byte>();
	int leapPoint = this->Width * 2;
	for (int i = 0; i < image->Length; i++) {
		if (this->Width % 2 != 0) {
			if (i == leapPoint) {
				i += 1;
				leapPoint += (this->Width * 2) + 2;
				continue;
			}
		}
		destination->Add(image[i]);
	}
	auto arr = destination->ToArray();
	unsigned char* frame = array_conversion<unsigned char*, unsigned char>(arr);
	uint8_t* f = (uint8_t*)frame;
	vo_->send(f);
}