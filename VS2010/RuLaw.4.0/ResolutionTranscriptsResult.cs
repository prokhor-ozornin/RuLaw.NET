﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Catharsis.Commons;
using Newtonsoft.Json;

namespace RuLaw
{
  /// <summary>
  ///   <para>Transcript of Duma law's resolution.</para>
  /// </summary>
  [XmlType("result")]
  public sealed class ResolutionTranscriptsResult : IEquatable<ResolutionTranscriptsResult>
  {
    /// <summary>
    ///   <para>Collection of Duma's meetings.</para>
    /// </summary>
    [JsonProperty("meetings")]
    [XmlElement("meeting")]
    public List<TranscriptMeeting> Meetings { get; set; }

    /// <summary>
    ///   <para>Number of resolution.</para>
    /// </summary>
    [JsonProperty("number")]
    [XmlElement("number")]
    public string Number { get; set; }

    /// <summary>
    ///   <para>Creates new transcript of Duma law's resolution.</para>
    /// </summary>
    public ResolutionTranscriptsResult()
    {
      this.Meetings = new List<TranscriptMeeting>();
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="ResolutionTranscriptsResult"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(ResolutionTranscriptsResult other)
    {
      return this.Equality(other, result => result.Number);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return this.Equals(other as ResolutionTranscriptsResult);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(result => result.Number);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="ResolutionTranscriptsResult"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="ResolutionTranscriptsResult"/>.</returns>
    public override string ToString()
    {
      return this.Number;
    }
  }
}