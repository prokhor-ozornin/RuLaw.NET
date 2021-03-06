﻿namespace RuLaw
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Xml.Serialization;
  using Catharsis.Commons;
  using Newtonsoft.Json;

  /// <summary>
  ///   <para>Transcript's question.</para>
  /// </summary>
  [XmlType("question")]
  public sealed class TranscriptMeetingQuestion : IComparable<ITranscriptMeetingQuestion>, IEquatable<ITranscriptMeetingQuestion>, ITranscriptMeetingQuestion
  {
    /// <summary>
    ///   <para>Title of question.</para>
    /// </summary>
    [JsonProperty("name")]
    [XmlElement("name")]
    public string Name { get; set; }

    /// <summary>
    ///   <para>List of transcript's fragments.</para>
    /// </summary>
    [JsonIgnore]
    [XmlIgnore]
    public IEnumerable<ITranscriptMeetingQuestionPart> Parts
    {
      get { return PartsOriginal.Cast<ITranscriptMeetingQuestionPart>(); }
    }

    /// <summary>
    ///   <para>List of transcript's fragments.</para>
    /// </summary>
    [JsonProperty("parts")]
    [XmlElement("part")]
    public List<TranscriptMeetingQuestionPart> PartsOriginal { get; set; }

    /// <summary>
    ///   <para>Question's review stage.</para>
    /// </summary>
    [JsonProperty("stage")]
    [XmlElement("stage")]
    public string Stage { get; set; }

    /// <summary>
    ///   <para>Creates new transcript's question.</para>
    /// </summary>
    public TranscriptMeetingQuestion()
    {
      PartsOriginal = new List<TranscriptMeetingQuestionPart>();
    }

    /// <summary>
    ///   <para>Compares the current <see cref="ITranscriptMeetingQuestion"/> instance with another.</para>
    /// </summary>
    /// <returns>A value that indicates the relative order of the instances being compared.</returns>
    /// <param name="other">The <see cref="ITranscriptMeetingQuestion"/> to compare with this instance.</param>
    public int CompareTo(ITranscriptMeetingQuestion other)
    {
      return Name.CompareTo(other.Name, StringComparison.InvariantCultureIgnoreCase);
    }

    /// <summary>
    ///   <para>Determines whether two <see cref="ITranscriptMeetingQuestion"/> instances are equal.</para>
    /// </summary>
    /// <param name="other">The instance to compare with the current one.</param>
    /// <returns><c>true</c> if specified instance is equal to the current, <c>false</c> otherwise.</returns>
    public bool Equals(ITranscriptMeetingQuestion other)
    {
      return this.Equality(other, question => question.Name, question => question.Stage);
    }

    /// <summary>
    ///   <para>Determines whether the specified <see cref="object"/> is equal to the current <see cref="object"/>.</para>
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><c>true</c> if the specified object is equal to the current object, <c>false</c>.</returns>
    public override bool Equals(object other)
    {
      return Equals(other as ITranscriptMeetingQuestion);
    }

    /// <summary>
    ///   <para>Returns hash code for the current object.</para>
    /// </summary>
    /// <returns>Hash code of current instance.</returns>
    public override int GetHashCode()
    {
      return this.GetHashCode(question => question.Name, question => question.Stage);
    }

    /// <summary>
    ///   <para>Returns a <see cref="string"/> that represents the current <see cref="TranscriptMeetingQuestion"/> instance.</para>
    /// </summary>
    /// <returns>A string that represents the current <see cref="TranscriptMeetingQuestion"/>.</returns>
    public override string ToString()
    {
      return Name;
    }
  }
}