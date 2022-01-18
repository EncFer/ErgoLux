﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ErgoLux
{
    /// <summary>
    /// Keeps the settings for the T-10 device, plottting options and app window properties
    /// </summary>
    public class ClassSettings
    {
        [JsonPropertyName("Window top")]
        public int Wnd_Top { get; set; }
        [JsonPropertyName("Window left")]
        public int Wnd_Left { get; set; }
        [JsonPropertyName("Window width")]
        public int Wnd_Width { get; set; }
        [JsonPropertyName("Window height")]
        public int Wnd_Height { get; set; }

        [JsonPropertyName("Location id")]
        public int T10_LocationID { get; set; }
        [JsonPropertyName("Number of sensors")]
        public int T10_NumberOfSensors { get; set; }
        [JsonPropertyName("Baud rate")]
        public int T10_BaudRate { get; set; }
        [JsonPropertyName("Data bits")]
        public int T10_DataBits { get; set; }
        [JsonPropertyName("Stop bits")]
        public int T10_StopBits { get; set; }
        [JsonPropertyName("Parity")]
        public int T10_Parity { get; set; }
        [JsonPropertyName("Flow control")]
        public int T10_FlowControl { get; set; }
        [JsonPropertyName("Character on")]
        public int T10_CharOn { get; set; }
        [JsonPropertyName("Chareacter off")]
        public int T10_CharOff { get; set; }
        [JsonPropertyName("Sample frequency")]
        public double T10_Frequency { get; set; }


        /// <value>Number of points the array can store</value>
        [JsonPropertyName("Array points")]
        public int Plot_ArrayPoints { get; set; }

        /// <value>Seconds to show in the abscissa axis</value>
        [JsonPropertyName("Plots moving window points")]
        public int Plot_WindowPoints { get; set; }

        /// <value><see langword="True" /> if the plot gets updated, <see langword="false" /> otherwise</value>
        [JsonPropertyName("Show illuminance plot")]
        public bool Plot_ShowRawData { get; set; }
        
        [JsonPropertyName("Show distribution plot")]
        public bool Plot_ShowDistribution { get; set; }
        
        [JsonPropertyName("Show average plot")]
        public bool Plot_ShowAverage { get; set; }
        
        [JsonPropertyName("Show ratios plot")]
        public bool Plot_ShowRatios { get; set; }

        [JsonPropertyName("Distribution is radar")]
        public bool Plot_DistIsRadar { get; set; }
        /// <summary>
        /// The number of pixels between two legends
        /// </summary>
        [JsonPropertyName("Pixels between legends")]
        public int PxBetweenLegends { get; set; }    

        /// <summary>
        /// Icon indicating the T-10 is opened and ready to be sent commands
        /// </summary>
        [JsonIgnore]
        public System.Drawing.Bitmap Icon_Open { get; set; }
        /// <summary>
        /// Icon indicating the T-10 is closed
        /// </summary>
        [JsonIgnore]
        public System.Drawing.Bitmap Icon_Close { get; set; }
        /// <summary>
        /// Icon indicating the T-10 receiving and sending data
        /// </summary>
        [JsonIgnore]
        public System.Drawing.Bitmap Icon_Data { get; set; }
        
        /// <summary>
        /// Stores the settings file name
        /// </summary>
        [JsonIgnore]
        public string FileName { get; set; }
        /// <summary>
        /// Absolute path of the executable
        /// </summary>
        [JsonIgnore]
        public string Path { get; set; }
        /// <summary>
        /// Number of columns reserved for computed (not measured) values
        /// </summary>
        [JsonIgnore]
        public int ArrayFixedColumns { get; set; }
        
        /// <summary>
        /// Culture used throughout the app
        /// </summary>
        [JsonIgnore]
        public System.Globalization.CultureInfo AppCulture { get; set; } = System.Globalization.CultureInfo.CurrentCulture;

        /// <summary>
        /// Define the culture used throughout the app by asigning a culture string name
        /// </summary>
        [JsonPropertyName("Culture")]
        public string AppCultureName
        {
            get { return AppCulture.Name; }
            set { AppCulture = new System.Globalization.CultureInfo(value); }
        }

        /// <summary>
        /// Milliseconds format
        /// </summary>
        [JsonIgnore]
        public string MillisecondsFormat
        {
            get { return $"$1{AppCulture.NumberFormat.NumberDecimalSeparator}fff"; }
        }

        /// <summary>
        /// Numeric data formatting string
        /// </summary>
        [JsonIgnore]
        public string DataFormat { get; set; }

        /// <summary>
        /// True if open/save dialogs should remember the user's previous path
        /// </summary>
        [JsonPropertyName("Remember path in FileDlg?")]
        public bool RememberFileDialogPath { get; set; }
        /// <summary>
        /// Default path for saving files to disk
        /// </summary>
        [JsonPropertyName("Default save path")]
        public string DefaultSavePath { get; set; }
        /// <summary>
        /// User-defined path for saving files to disk
        /// </summary>
        [JsonPropertyName("User save path")]
        public string UserSavePath { get; set; }
        /// <summary>
        /// Default path for reading files from disk
        /// </summary>
        [JsonPropertyName("Default open path")]
        public string DefaultOpenPath { get; set; }
        /// <summary>
        /// User-defined path for reading files from disk
        /// </summary>
        [JsonPropertyName("User open path")]
        public string UserOpenPath { get; set; }
        
        
        public ClassSettings()
        {
            Wnd_Top = 0;
            Wnd_Left = 0;
            Wnd_Width = 950;
            Wnd_Height = 650;

            T10_BaudRate = 9600;
            T10_CharOff = 13;
            T10_CharOn = 11;
            T10_DataBits = 7;
            T10_FlowControl = 0;
            T10_Frequency = 2;
            T10_LocationID = 0;
            T10_NumberOfSensors = 1;
            T10_Parity = 2; ;
            T10_StopBits = 0;

            Plot_ArrayPoints = 7200;
            Plot_WindowPoints = 20;
            Plot_ShowRawData = true;
            Plot_ShowDistribution = true;
            Plot_ShowAverage = true;
            Plot_ShowRatios = true;
            Plot_DistIsRadar = true;

            PxBetweenLegends = 10;

            FileName = "configuration.json";
            Path = string.Empty;
            ArrayFixedColumns = 6;

            AppCulture = System.Globalization.CultureInfo.CurrentCulture;

            RememberFileDialogPath = true;

            DataFormat = "#0.0##";

            DefaultSavePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            UserSavePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            DefaultOpenPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\examples";
            UserOpenPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\examples";
        }

        public ClassSettings(string path)
            :this()
        {
            Path = path;
            if (System.IO.File.Exists(path + @"\images\close.ico")) Icon_Close = new System.Drawing.Icon(path + @"\images\close.ico", 16, 16).ToBitmap();
            if (System.IO.File.Exists(path + @"\images\open.ico")) Icon_Open = new System.Drawing.Icon(path + @"\images\open.ico", 16, 16).ToBitmap();
            if (System.IO.File.Exists(path + @"\images\exchange.ico")) Icon_Data = new System.Drawing.Icon(path + @"\images\exchange.ico", 16, 16).ToBitmap();
        }

        ~ClassSettings()
        {
            if (Icon_Open != null) Icon_Open.Dispose();
            if (Icon_Close != null) Icon_Close.Dispose();
            if (Icon_Data != null) Icon_Data.Dispose();
        }

        /// <summary>
        /// Initializes all the fields that are Json-ignored
        /// </summary>
        public void InitializeJsonIgnore(string path = null)
        {
            FileName = "configuration.json";
            Path = path ?? string.Empty;
            ArrayFixedColumns = 6;

            if(Path != string.Empty)
            {
                if (System.IO.File.Exists(Path + @"\images\close.ico")) Icon_Close = new System.Drawing.Icon(Path + @"\images\close.ico", 16, 16).ToBitmap();
                if (System.IO.File.Exists(Path + @"\images\open.ico")) Icon_Open = new System.Drawing.Icon(Path + @"\images\open.ico", 16, 16).ToBitmap();
                if (System.IO.File.Exists(Path + @"\images\exchange.ico")) Icon_Data = new System.Drawing.Icon(Path + @"\images\exchange.ico", 16, 16).ToBitmap();
            }
        }
    }
}
