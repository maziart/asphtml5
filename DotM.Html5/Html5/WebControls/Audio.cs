using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.ComponentModel;

namespace DotM.Html5.WebControls
{
    /// <summary>
    ///  Represents an audio stream.
    /// </summary>
    public class Audio : ContainerControl
    {
        /// <summary>
        /// Creates a new instance of <c>Audio</c>
        /// </summary>
        public Audio() : base(ContainerType.Audio) { }


        /// <summary>
        /// Adds HTML attributes and styles that need to be rendered to the specified
        /// System.Web.UI.HtmlTextWriter instance.
        /// </summary>
        /// <param name="writer">An System.Web.UI.HtmlTextWriter that represents the output stream to render HTML content on the client</param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            base.AddAttributesToRender(writer);
            Helper.AddBooleanAttribute(writer, "autoplay", AutoPlay);
            Helper.AddLowerCaseEnumIfNotZero(writer, "preload", PreLoad);
            Helper.AddBooleanAttribute(writer, "controls", DisplayControls);
            Helper.AddBooleanAttribute(writer, "loop", Loop);
            Helper.AddStringAttributeIfNotEmpty(writer, "mediagroup", MediaGroup);
            Helper.AddUrlAttributeIfNotEmpty(writer, "src", Url, this);
        }

        /// <summary>
        /// Gets or sets a value that instructs the UA to automatically begin playback of the audio stream as soon as it can do so without stopping
        /// </summary>
        [DefaultValue(false), Description("Instructs the UA to automatically begin playback of the audio stream as soon as it can do so without stopping"), Themeable(false), Category("Behavior")]
        public bool AutoPlay { get; set; }

        /// <summary>
        /// Gets or sets a value that represents a hint to the UA about whether optimistic downloading of the audio stream itself or its metadata is considered worthwhile
        /// </summary>
        [DefaultValue(PreLoadMode.NotSet), Description("Represents a hint to the UA about whether optimistic downloading of the audio stream itself or its metadata is considered worthwhile"), Themeable(false), Category("Behavior")]
        public PreLoadMode PreLoad { get; set; }

        /// <summary>
        /// Gets or sets a value that instructs the UA to expose a user interface for controlling playback of the audio stream
        /// </summary>
        [DefaultValue(false), Description("Instructs the UA to expose a user interface for controlling playback of the audio stream"), Themeable(false), Category("Behavior")]
        public bool DisplayControls { get; set; }

        /// <summary>
        /// Gets or sets a value that instructs the UA to seek back to the start of the audio stream upon reaching the end
        /// </summary>
        [DefaultValue(false), Description("Instructs the UA to seek back to the start of the audio stream upon reaching the end"), Themeable(false), Category("Behavior")]
        public bool Loop { get; set; }
        
        /// <summary>
        /// Gets or sets a value that instructs the UA to link multiple videos and/or audio streams together
        /// </summary>
        [DefaultValue(""), Description("Instructs the UA to link multiple videos and/or audio streams together"), Themeable(false), Category("Behavior")]
        public string MediaGroup { get; set; }

        /// <summary>
        /// Gets or sets the URL for the audio stream
        /// </summary>
        [DefaultValue(""), Description("The URL for the audio stream"), Themeable(false), Category("Behavior"), UrlProperty]
        public string Url { get; set; }
    }
}
