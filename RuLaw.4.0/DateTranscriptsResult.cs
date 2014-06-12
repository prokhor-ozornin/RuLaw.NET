﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcripts search result.</para>
  /// </summary>
  [Description("Transcripts search result")]
  [XmlType("result")]
  public sealed class DateTranscriptsResult : IComparable<DateTranscriptsResult>, IEquatable<DateTranscriptsResult>, IDateable
  {
    /// <summary>
    ///   <para>Date of meetings.</para>
    /// </summary>
    [Description("Date of meetings")]
    [JsonIgnore]
    [XmlIgnore]
    public DateTime Date { get; set; }

    /// <summary>
    ///   <para>Date of meetings.</para>
    /// </summary>
    [Description("Date of meetings")]
    [JsonProperty("date")]
    [XmlElement("date")]
    public string DateString
    {
      get { return this.Date.ISO8601(); }
      set { this.Date = DateTime.Parse(value); }
    }

    /// <summary>
    ///   <para>List of meetings transcripts.</para>
    /// </summary>
    [Description("List of meetings transcripts")]
    [JsonProperty("meetings")]
    [XmlElement("meeting")]
    public List<DateTranscriptMeeting> Meetings { get; set; }

    /// <summary>
    ///   <para>Creates new transcripts search result.</para>
    /// </summary>
    public DateTranscriptsResult()
    {
      this.Meetings = new List<DateTranscriptMeeting>();
    }

    /// <summary>
    ///   <para>Compares the current transcripts search result with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <param name="other">The <see cref="DateTranscriptsResult"/> to compare with this instance.</param>
    public int CompareTo(DateTranscriptsResult other)
    {
      return this.Date.CompareTo(other.Date);
    }

    /// <summary>
    ///   <para>Determines whether two transcripts search results instances are equal.</para>
    /// </summary>
    /// <param name="other">The transcripts search result to compare with the current one.</param>
    /// <returns><c>true</c> if specified search result is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(DateTranscriptsResult other)
    {
      return this.Equality(other, result => result.Date);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as DateTranscriptsResult);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(result => result.Date);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current transcripts search result.</para>
    /// </summary>
    /// <returns>A string that represents the current transcripts search result.</returns>
    public override string ToString()
    {
      return this.Date.RuLawDate();
    }
  }
}