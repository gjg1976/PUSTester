﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PUS_tester.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("25")]
        public ushort ApplicationID {
            get {
                return ((ushort)(this["ApplicationID"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\config\\PUS_services.xml")]
        public string TC_XML_file {
            get {
                return ((string)(this["TC_XML_file"]));
            }
            set {
                this["TC_XML_file"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("65536")]
        public int Max_payload_size {
            get {
                return ((int)(this["Max_payload_size"]));
            }
            set {
                this["Max_payload_size"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("COM2")]
        public string DefaultCOMUART {
            get {
                return ((string)(this["DefaultCOMUART"]));
            }
            set {
                this["DefaultCOMUART"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\Logs\\SerialLogs\\")]
        public string SerialLogRxFilePath {
            get {
                return ((string)(this["SerialLogRxFilePath"]));
            }
            set {
                this["SerialLogRxFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\Logs\\SerialLogs\\")]
        public string SerialLogTxFilePath {
            get {
                return ((string)(this["SerialLogTxFilePath"]));
            }
            set {
                this["SerialLogTxFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\Logs\\")]
        public string LogFilePath {
            get {
                return ((string)(this["LogFilePath"]));
            }
            set {
                this["LogFilePath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int OBTType {
            get {
                return ((int)(this["OBTType"]));
            }
            set {
                this["OBTType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool PField {
            get {
                return ((bool)(this["PField"]));
            }
            set {
                this["PField"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1986-06-01")]
        public global::System.DateTime Epoch {
            get {
                return ((global::System.DateTime)(this["Epoch"]));
            }
            set {
                this["Epoch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4")]
        public int BasicTimeSize {
            get {
                return ((int)(this["BasicTimeSize"]));
            }
            set {
                this["BasicTimeSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int FracTimeSize {
            get {
                return ((int)(this["FracTimeSize"]));
            }
            set {
                this["FracTimeSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool CRCReports {
            get {
                return ((bool)(this["CRCReports"]));
            }
            set {
                this["CRCReports"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".\\config\\parametersdef.xml")]
        public string Param_XML_file {
            get {
                return ((string)(this["Param_XML_file"]));
            }
            set {
                this["Param_XML_file"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15")]
        public int ST8FunctionSize {
            get {
                return ((int)(this["ST8FunctionSize"]));
            }
            set {
                this["ST8FunctionSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15")]
        public int ST8FunctionArgSize {
            get {
                return ((int)(this["ST8FunctionArgSize"]));
            }
            set {
                this["ST8FunctionArgSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15")]
        public int ST21StringSize {
            get {
                return ((int)(this["ST21StringSize"]));
            }
            set {
                this["ST21StringSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15")]
        public int ST15StoresIDSize {
            get {
                return ((int)(this["ST15StoresIDSize"]));
            }
            set {
                this["ST15StoresIDSize"] = value;
            }
        }
    }
}
