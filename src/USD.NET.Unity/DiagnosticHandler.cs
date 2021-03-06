﻿// Copyright 2017 Google Inc. All rights reserved.
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

using System;
using UnityEngine;

namespace USD.NET.Unity {

  /// <summary>
  /// Implements a DiagnosticHandler which pipes messages to Unity's debug logger.
  /// </summary>
  public class DiagnosticHandler : pxr.DiagnosticHandler {
    private static DiagnosticHandler m_instance = new DiagnosticHandler();

    /// <summary>
    /// Registers this class a the global diagnostic handler.
    /// </summary>
    public static void Register() {
      pxr.DiagnosticHandler.SetGlobalHandler(m_instance);
    }

    /// <summary>
    /// Messages sent when an unrecoverable fatal error occured in the USD API.
    /// </summary>
    public override void OnFatalError(string msg) {
      // Note: the system is about to abort().
      throw new Exception("USD FATAL ERROR: " + msg);
    }

    /// <summary>
    /// Messages sent when an error occured in the USD API, but was not fatal.
    /// </summary>
    public override void OnError(string msg) {
      // An error has occured, but was not fatal.
      throw new ApplicationException("USD: " + msg);
    }

    /// <summary>
    /// Warning messages sent from the USD API upon misuse or unexpected run-time conditions.
    /// </summary>
    public override void OnWarning(string msg) {
      Debug.LogWarning("USD: " + msg);
    }

    /// <summary>
    /// Informational messages sent from the USD API.
    /// </summary>
    public override void OnInfo(string msg) {
      Debug.Log("USD: " + msg);
    }
  }
}
