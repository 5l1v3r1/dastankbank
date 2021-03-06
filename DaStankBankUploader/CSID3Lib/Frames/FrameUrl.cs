// Copyright(C) 2002-2009 Hugo Rumayor Montemayor, All rights reserved.
using System;
using System.Text;
using System.IO;

namespace Id3Lib
{
    /// <summary>
    /// Manages predefined URL W*** (not WXXX) Frames
    /// </summary>
    /// <remarks>
    /// URL               text string
    /// </remarks>
    [Frame("W")]
    public class FrameUrl : FrameBase
    {
        #region Fields
        private string _url;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a URL frame
        /// </summary>
        /// <param name="frameId">Type of URL frame</param>
        public FrameUrl(string frameId)
            : base(frameId)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// The URL page location
        /// </summary>
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Parse the binary frame
        /// </summary>
        /// <param name="frame">binary frame</param>
        public override void Parse(byte[] frame)
        {
            //TODO: Handle this invalid tag
            if (frame.Length < 1)
                return;

            int index = 0;
            _url = TextBuilder.ReadTextEnd(frame, index, TextCode.Ascii);
        }

        /// <summary>
        /// Create a binary frame
        /// </summary>
        /// <returns>binary frame</returns>
        public override byte[] Make()
        {
            MemoryStream buffer = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(buffer);
            writer.Write(TextBuilder.WriteTextEnd(_url, TextCode.Ascii));
            return buffer.ToArray();
        }
        /// <summary>
        /// Default frame description
        /// </summary>
        /// <returns>URL text</returns>
        public override string ToString()
        {
            return _url;
        }
        #endregion
    }
}
