// Copyright 2017 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

%module gfMatrix4d

%{
#include "pxr/base/gf/matrix4d.h"
%}

IGNORE_OPERATORS(GfMatrix2d)

%ignore GfMatrix4d(const double m[4][4]);
%ignore GfMatrix4d::Set(const double m[4][4]);
%ignore GfMatrix4d::Get(double m[4][4]);
%ignore GfMatrix4d::GetArray;

%include <arrays_csharp.i>

WRAP_EQUAL(GfMatrix4d)

%include "pxr/base/gf/matrix4d.h"

%extend GfMatrix4d {
	%csmethodmodifiers ToString() "public override";
    std::string ToString() {
	    std::stringstream s;
		s << *self;
		return s.str();
	}

	%apply double OUTPUT[] { double* dest }
    void CopyToArray(double* dest) {
		memcpy(dest, self->GetArray(), 16 * sizeof(double)); 
	}

	%apply double INPUT[] { double* src }
	void CopyFromArray(double* src) { 
		memcpy(self->GetArray(), src, 16 * sizeof(double));
	}
}