﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IApiCallerExtensions"/>.</para>
  /// </summary>
  public sealed class IApiCallerExtensionsTests
  {
    private readonly IApiCaller xmlApiCaller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Xml));
    private readonly IApiCaller jsonApiCaller = RuLaw.API(api => api.ApiKey(ConfigurationManager.AppSettings["ApiKey"]).AppKey(ConfigurationManager.AppSettings["AppKey"]).Format(ApiDataFormat.Json));

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IApiCallerExtensions.Branches(IApiCaller)"/></description></item>
    ///     <item><description><see cref="IApiCallerExtensions.Branches(IApiCaller, out IEnumerable{ILawBranch})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Branches_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Branches(null));

      IEnumerable<ILawBranch> branches;

      TestBranches(xmlApiCaller.Branches());
      Assert.True(xmlApiCaller.Branches(out branches));
      TestBranches(branches);

      TestBranches(jsonApiCaller.Branches());
      Assert.True(jsonApiCaller.Branches(out branches));
      TestBranches(branches);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IApiCallerExtensions.Committees(IApiCaller)"/></description></item>
    ///     <item><description><see cref="IApiCallerExtensions.Committees(IApiCaller, out IEnumerable{ICommittee})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Committees_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Committees(null));

      IEnumerable<ICommittee> committees;
      
      TestCommittees(xmlApiCaller.Committees());
      Assert.True(xmlApiCaller.Committees(out committees));
      TestCommittees(committees);

      TestCommittees(jsonApiCaller.Committees());
      Assert.True(jsonApiCaller.Committees(out committees));
      TestCommittees(committees);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IApiCallerExtensions.Convocations(IApiCaller)"/></description></item>
    ///     <item><description><see cref="IApiCallerExtensions.Convocations(IApiCaller, out IEnumerable{IConvocation})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Convocations_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Convocations(null));

      IEnumerable<IConvocation> convocations;

      TestConvocations(xmlApiCaller.Convocations());
      Assert.True(xmlApiCaller.Convocations(out convocations));
      TestConvocations(convocations);

      TestConvocations(jsonApiCaller.Convocations());
      Assert.True(jsonApiCaller.Convocations(out convocations));
      TestConvocations(convocations);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IApiCallerExtensions.Deputy(IApiCaller, long)"/></description></item>
    ///     <item><description><see cref="IApiCallerExtensions.Deputy(IApiCaller, long, out IDeputyInfo)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Deputy_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Deputy(null, 0));

      const long id = 99100142;
      IDeputyInfo deputy;

      TestDeputyInfo(xmlApiCaller.Deputy(id));
      Assert.True(xmlApiCaller.Deputy(id, out deputy));
      TestDeputyInfo(deputy);

      TestDeputyInfo(jsonApiCaller.Deputy(id));
      Assert.True(jsonApiCaller.Deputy(id, out deputy));
      TestDeputyInfo(deputy);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IApiCallerExtensions.Deputies(IApiCaller, Action{IDeputiesLawApiCall})"/></description></item>
    ///     <item><description><see cref="IApiCallerExtensions.Deputies(IApiCaller, out IEnumerable{IDeputy}, Action{IDeputiesLawApiCall})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Deputies_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Deputies(null));

      IEnumerable<IDeputy> deputies;

      TestDeputies(xmlApiCaller.Deputies());
      Assert.True(xmlApiCaller.Deputies(out deputies));
      TestDeputies(deputies);

      TestDeputies(jsonApiCaller.Deputies());
      Assert.True(jsonApiCaller.Deputies(out deputies));
      TestDeputies(deputies);

      var call = (Action<IDeputiesLawApiCall>)(x => x.Position(DeputyPosition.DumaDeputy).Current(false).Name("А"));
      
      TestDeputies(xmlApiCaller.Deputies(call));
      Assert.True(xmlApiCaller.Deputies(out deputies, call));
      TestDeputies(deputies);

      TestDeputies(jsonApiCaller.Deputies(call));
      Assert.True(jsonApiCaller.Deputies(out deputies, call));
      TestDeputies(deputies);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IApiCallerExtensions.FederalAuthorities(IApiCaller, Action{IAuthoritiesLawApiCall})"/></description></item>
    ///     <item><description><see cref="IApiCallerExtensions.FederalAuthorities(IApiCaller, out IEnumerable{IAuthority}, Action{IAuthoritiesLawApiCall})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void FederalAuthorities_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.FederalAuthorities(null));

      IEnumerable<IAuthority> authorities;

      TestFederalAuthorities(xmlApiCaller.FederalAuthorities());
      Assert.True(xmlApiCaller.FederalAuthorities(out authorities));
      TestFederalAuthorities(authorities);

      TestFederalAuthorities(jsonApiCaller.FederalAuthorities());
      Assert.True(jsonApiCaller.FederalAuthorities(out authorities));
      TestFederalAuthorities(authorities);

      var call = (Action<IAuthoritiesLawApiCall>) (x => x.Current());

      TestFederalAuthorities(xmlApiCaller.FederalAuthorities(call));
      Assert.True(xmlApiCaller.FederalAuthorities(out authorities, call));
      TestFederalAuthorities(authorities);

      TestFederalAuthorities(jsonApiCaller.FederalAuthorities(call));
      Assert.True(jsonApiCaller.FederalAuthorities(out authorities, call));
      TestFederalAuthorities(authorities);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IApiCallerExtensions.Instances(IApiCaller, Action{IInstancesLawApiCall})"/></description></item>
    ///     <item><description><see cref="IApiCallerExtensions.Instances(IApiCaller, out IEnumerable{IInstance}, Action{IInstancesLawApiCall})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Instances_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Instances(null));

      IEnumerable<IInstance> instances;

      TestInstances(xmlApiCaller.Instances());
      Assert.True(xmlApiCaller.Instances(out instances));
      TestInstances(instances);

      TestInstances(jsonApiCaller.Instances());
      Assert.True(jsonApiCaller.Instances(out instances));
      TestInstances(instances);

      var call = (Action<IInstancesLawApiCall>)(x => x.Current());

      TestInstances(xmlApiCaller.Instances(call));
      Assert.True(xmlApiCaller.Instances(out instances, call));
      TestInstances(instances);

      TestInstances(jsonApiCaller.Instances(call));
      Assert.True(jsonApiCaller.Instances(out instances, call));
      TestInstances(instances);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IApiCallerExtensions.Laws(IApiCaller, Action{ILawsLawApiCall})"/></description></item>
    ///     <item><description><see cref="IApiCallerExtensions.Laws(IApiCaller, Action{ILawsLawApiCall}, out ILawsSearchResult)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Laws_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Laws(null, request => { }));
      Assert.Throws<ArgumentNullException>(() => xmlApiCaller.Laws(null));

      ILawsSearchResult result;

      var call = (Action<ILawsLawApiCall>) (x => x.Name("курение").Sorting(LawsSorting.DateDescending));

      TestLawsSearchResult(xmlApiCaller.Laws(call));
      Assert.True(xmlApiCaller.Laws(call, out result));
      TestLawsSearchResult(result);

      TestLawsSearchResult(jsonApiCaller.Laws(call));
      Assert.True(jsonApiCaller.Laws(call, out result));
      TestLawsSearchResult(result);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IApiCallerExtensions.Questions(IApiCaller, Action{IQuestionsLawApiCall})"/></description></item>
    ///     <item><description><see cref="IApiCallerExtensions.Questions(IApiCaller, out IQuestionsSearchResult, Action{IQuestionsLawApiCall})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Questions_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Questions(null));

      IQuestionsSearchResult result;

      var call = (Action<IQuestionsLawApiCall>)(x => x.From(new DateTime(2013, 1, 1)).To(new DateTime(2013, 12, 31)).Name("образование").PageSize(PageSize.Five).Page(2));

      TestQuestionsSearchResult(xmlApiCaller.Questions(call));
      Assert.True(xmlApiCaller.Questions(out result, call));
      TestQuestionsSearchResult(result);

      TestQuestionsSearchResult(jsonApiCaller.Questions(call));
      Assert.True(jsonApiCaller.Questions(out result, call));
      TestQuestionsSearchResult(result);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IApiCallerExtensions.RegionalAuthorities(IApiCaller, Action{IAuthoritiesLawApiCall})"/></description></item>
    ///     <item><description><see cref="IApiCallerExtensions.RegionalAuthorities(IApiCaller, out IEnumerable{IAuthority}, Action{IAuthoritiesLawApiCall})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void RegionalAuthorities_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.RegionalAuthorities(null));

      IEnumerable<IAuthority> authorities;

      TestRegionalAuthorities(xmlApiCaller.RegionalAuthorities());
      Assert.True(xmlApiCaller.RegionalAuthorities(out authorities));
      TestRegionalAuthorities(authorities);

      TestRegionalAuthorities(jsonApiCaller.RegionalAuthorities());
      Assert.True(jsonApiCaller.RegionalAuthorities(out authorities));
      TestRegionalAuthorities(authorities);

      var call = (Action<IAuthoritiesLawApiCall>)(x => x.Current(false));

      TestRegionalAuthorities(xmlApiCaller.RegionalAuthorities(call));
      Assert.True(xmlApiCaller.RegionalAuthorities(out authorities, call));
      TestRegionalAuthorities(authorities);

      TestRegionalAuthorities(jsonApiCaller.RegionalAuthorities(call));
      Assert.True(jsonApiCaller.RegionalAuthorities(out authorities, call));
      TestRegionalAuthorities(authorities);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IApiCallerExtensions.Requests(IApiCaller)"/></description></item>
    ///     <item><description><see cref="IApiCallerExtensions.Requests(IApiCaller, out IEnumerable{IDeputyRequest})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Requests_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Requests(null));

      IEnumerable<IDeputyRequest> requests;

      TestRequests(xmlApiCaller.Requests());
      Assert.True(xmlApiCaller.Requests(out requests));
      TestRequests(requests);

      TestRequests(jsonApiCaller.Requests());
      Assert.True(jsonApiCaller.Requests(out requests));
      TestRequests(requests);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IApiCallerExtensions.Stages(IApiCaller)"/></description></item>
    ///     <item><description><see cref="IApiCallerExtensions.Stages(IApiCaller, out IEnumerable{IPhaseStage})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Stages_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Stages(null));

      IEnumerable<IPhaseStage> stages;

      TestStages(xmlApiCaller.Stages());
      Assert.True(xmlApiCaller.Stages(out stages));
      TestStages(stages);

      TestStages(jsonApiCaller.Stages());
      Assert.True(jsonApiCaller.Stages(out stages));
      TestStages(stages);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="IApiCallerExtensions.Topics(IApiCaller)"/></description></item>
    ///     <item><description><see cref="IApiCallerExtensions.Topics(IApiCaller, out IEnumerable{ITopic})"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Topics_Methods()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Topics(null));

      IEnumerable<ITopic> topics;

      TestTopics(xmlApiCaller.Topics());
      Assert.True(xmlApiCaller.Topics(out topics));
      TestTopics(topics);

      TestTopics(jsonApiCaller.Topics());
      Assert.True(jsonApiCaller.Topics(out topics));
      TestTopics(topics);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Transcripts(IApiCaller)"/> method.</para>
    /// </summary>
    [Fact]
    public void Transcripts_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Transcripts(null));

      Assert.True(xmlApiCaller.Transcripts() is TranscriptsApiCaller);
      Assert.False(ReferenceEquals(xmlApiCaller.Transcripts(), xmlApiCaller.Transcripts()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IApiCallerExtensions.Votes(IApiCaller)"/> method.</para>
    /// </summary>
    [Fact]
    public void Votes_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IApiCallerExtensions.Votes(null));

      Assert.True(xmlApiCaller.Votes() is VotesApiCaller);
      Assert.False(ReferenceEquals(xmlApiCaller.Votes(), xmlApiCaller.Votes()));
    }

    private void TestBranches(IEnumerable<ILawBranch> branches)
    {
      Assertion.NotNull(branches);

      Assert.True(branches is List<LawBranch>);
      Assert.NotEmpty(branches);
      var branch = branches.Single(x => x.Id == 68252);
      Assert.Equal("Безопасность и охрана правопорядка", branch.Name);
    }

    private void TestCommittees(IEnumerable<ICommittee> committees)
    {
      Assertion.NotNull(committees);

      Assert.True(committees is List<Committee>);
      Assert.NotEmpty(committees);
      var commmittee = committees.Single(x => x.Id == 6274200);
      Assert.Equal("Комитет ГД по аграрным вопросам", commmittee.Name);
      Assert.Equal(new DateTime(1994, 1, 20), commmittee.FromDate);
    }

    private void TestConvocations(IEnumerable<IConvocation> convocations)
    {
      Assertion.NotNull(convocations);

      Assert.True(convocations is List<Convocation>);
      Assert.NotEmpty(convocations);
      var convocation = convocations.Single(x => x.Id == 82100004);
      Assert.Equal("4-ый созыв", convocation.Name);
      Assert.Equal(new DateTime(2003, 12, 29), convocation.FromDate);
      Assert.Equal(new DateTime(2007, 12, 23), convocation.ToDate);
      Assert.Equal(8, convocation.Sessions.Count());
      
      var session = convocation.Sessions.ElementAt(0);
      Assert.Equal(82200021, session.Id);
      Assert.Equal("Весенняя сессия 2004 г.", session.Name);
      Assert.Equal(new DateTime(2004, 1, 12), session.FromDate);
      Assert.Equal(new DateTime(2004, 7, 10), session.ToDate);

      session = convocation.Sessions.ElementAt(1);
      Assert.Equal(82200022, session.Id);
      Assert.Equal("Осенняя сессия 2004 г.", session.Name);
      Assert.Equal(new DateTime(2004, 9, 1), session.FromDate);
      Assert.Equal(new DateTime(2004, 12, 31), session.ToDate);
    }

    private void TestDeputies(IEnumerable<IDeputy> deputies)
    {
      Assertion.NotNull(deputies);

      Assert.True(deputies is List<Deputy>);
      Assert.NotEmpty(deputies);
      var deputy = deputies.Single(x => x.Id == 99100491);
      Assert.Equal("Абдулатипов Рамазан Гаджимурадович", deputy.Name);
      Assert.Equal("Депутат ГД", deputy.Position);
      Assert.False(deputy.Active);
    }

    private void TestDeputyInfo(IDeputyInfo deputy)
    {
      Assertion.NotNull(deputy);

      Assert.Equal("Жириновский", deputy.LastName);
      Assert.Equal("Владимир", deputy.FirstName);
      Assert.Equal("Вольфович", deputy.MiddleName);
      Assert.Equal(new DateTime(1946, 4, 25), deputy.BirthDate);
      Assert.Equal(new DateTime(2016, 9, 18), deputy.WorkStartDate);
      Assert.Equal(72100005, deputy.FactionId);
      Assert.Equal("Фракция Политической партии ЛДПР - Либерально-демократической партии России", deputy.FactionName);
      Assert.Equal("00020 Руководитель фракции", deputy.FactionRole.Trim());
      Assert.True(deputy.Active);
      Assert.Equal("(Общефедеральная часть федерального списка кандидатов).", deputy.FactionRegion);
      Assert.True(deputy.LawsCount > 0);
      Assert.Contains("все субъекты Российской Федерации", deputy.Regions);
      Assert.True(deputy.SpeachesCount > 0);
      Assert.Equal("http://vote.duma.gov.ru/?convocation=AAAAAAA7&deputy=99100142&sort=date_desc", deputy.VoteLink);
      Assert.Equal("http://www.cir.ru/duma/servlet/is4.wwwmain?FormName=ProcessQuery&Action=RunQuery&PDCList=*&QueryString=%2FGD_%C4%C5%CF%D3%D2%C0%D2%3D%22%C6%C8%D0%C8%CD%CE%C2%D1%CA%C8%C9+%C2.%C2.%22", deputy.TranscriptLink);

      Assert.Contains(deputy.Educations, education => education.Institution == "Московский государственный университет имени М.В.Ломоносова (институт восточных языков)" && education.Year == 1970);

      Assert.Contains("Доктор философских наук", deputy.Degrees);

      Assert.Contains("Профессор", deputy.Ranks);
      Assert.Contains("Действительный член (академик) Международной Академии экологии и природопользования (МАЭП)", deputy.Ranks);
      Assert.Contains("Почетный академик Академии естествознания", deputy.Ranks);
      Assert.Contains("Действительный член Международной Академии информатизации", deputy.Ranks);
      Assert.Contains("Действительный член (академик) Академии социальных наук", deputy.Ranks);
    }

    private void TestFederalAuthorities(IEnumerable<IAuthority> authorities)
    {
      Assertion.NotNull(authorities);

      Assert.True(authorities is List<FederalAuthority>);
      Assert.NotEmpty(authorities);
      var authority = authorities.Single(x => x.Id == 6231000);
      Assert.Equal("Верховный Суд РФ", authority.Name);
      Assert.True(authority.Active);
      Assert.Equal(new DateTime(1994, 1, 1), authority.FromDate);
      Assert.Null(authority.ToDate);
    }

    private void TestLawsSearchResult(ILawsSearchResult result)
    {
      Assertion.NotNull(result);

      Assert.True(result.Count > 0);
      Assert.Equal(1, result.Page);
      Assert.Equal("Законопроекты, где наименование или комментарий содержит \"курение\", отсортированные по дате внесения в ГД (по убыванию)", result.Wording);

      var laws = result.Laws;
      Assert.NotEmpty(laws);
      
      var law = laws.Number("170826-6");
      
      Assert.Null(law.Comments);

      var committee = law.Committees.Profile.Single();
      Assert.True(committee.Active);
      Assert.Equal(new DateTime(2003, 12, 29), committee.FromDate);
      Assert.Null(committee.ToDate);
      Assert.Null(law.Committees.Responsible);
      Assert.Empty(law.Committees.SoExecutor);

      Assert.Equal(new DateTime(2012, 11, 13), law.Date);
      
      Assert.Equal(19135, law.Id);
      
      Assert.Equal(new DateTime(2012, 12, 20), law.LastEvent.Date);
      Assert.Equal("68", law.LastEvent.Document.Name);
      Assert.Equal("Протокол заседания Совета ГД", law.LastEvent.Document.Type);
      Assert.Equal(5, law.LastEvent.Phase.Id);
      Assert.Equal("Рассмотрение Советом Государственной Думы законопроекта, внесенного в Государственную Думу", law.LastEvent.Phase.Name);
      Assert.Equal("снять законопроект с рассмотрения Государственной Думы в связи с отзывом субъектом права законодательной инициативы", law.LastEvent.Solution);
      Assert.Equal(2, law.LastEvent.Stage.Id);
      Assert.Equal("Предварительное рассмотрение законопроекта, внесенного в Государственную Думу", law.LastEvent.Stage.Name);

      Assert.Equal("Об ограничении курения табака в целях охраны здоровья населения", law.Name);

      Assert.Equal("170826-6", law.Number);

      Assert.Empty(law.Subject.Departments);

      var deputy = law.Subject.Deputies.Single();
      Assert.Equal(99100270, deputy.Id);
      Assert.Equal(DeputyPosition.DumaDeputy, deputy.Position());
      Assert.Equal("Митрофанов Алексей Валентинович", deputy.Name);

      Assert.Null(law.TranscriptUrl);

      Assert.Equal((int) LawTypes.Federal, law.Type.Id);
      Assert.Equal("Федеральный закон", law.Type.Name);

      Assert.Equal("http://sozd.parlament.gov.ru/bill/170826-6", law.Url);
    }

    private void TestInstances(IEnumerable<IInstance> instances)
    {
      Assertion.NotNull(instances);

      Assert.True(instances is List<Instance>);
      Assert.NotEmpty(instances);
      var instance = instances.Single(x => x.Id == 177);
      Assert.Equal("ГД (Пленарное заседание)", instance.Name);
      Assert.True(instance.Active);
    }

    private void TestQuestionsSearchResult(IQuestionsSearchResult result)
    {
      Assertion.NotNull(result);

      Assert.Equal(44, result.Count);
      Assert.Equal(2, result.Page);
      Assert.Equal((int) PageSize.Five, result.PageSize);

      var questions = result.Questions;
      Assert.True(questions is IList<Question>);
      Assert.NotEmpty(questions);
      Assert.Equal(5, questions.Count());

      var question = questions.ElementAt(0);
      Assert.Equal(@"О проекте федерального закона № 641168-5 ""Об образовании постоянных судебных присутствий в составе некоторых районных судов Ростовской области"".", question.Name);
      Assert.Equal(new DateTime(2013, 11, 19), question.Date);
      Assert.Equal(1367, question.SessionCode);
      Assert.Equal(8, question.Code);
      Assert.Equal(1379, question.StartLine);
      Assert.Equal(6569, question.EndLine);

      question = questions.ElementAt(1);
      Assert.Equal(@"О проекте федерального закона № 641168-5 ""Об образовании постоянных судебных присутствий в составе некоторых районных судов Ростовской области"" (принят в первом чтении 11 октября 2013 года с наименованием ""Об образовании в некоторых районных судах Ростовской области постоянных судебных присутствий"").", question.Name);
      Assert.Equal(new DateTime(2013, 11, 15), question.Date);
      Assert.Equal(1366, question.SessionCode);
      Assert.Equal(18, question.Code);
      Assert.Equal(2096, question.StartLine);
      Assert.Equal(5763, question.EndLine);

      question = questions.ElementAt(2);
      Assert.Equal(@"О проекте федерального закона № 249992-6 ""О внесении изменений в Федеральный закон ""Об общих принципах организации местного самоуправления в Российской Федерации"" (в части установления порядка избрания главы муниципального образования в поселениях с численностью жителей, обладающих избирательным правом, более 30 тысяч человек).", question.Name);
      Assert.Equal(new DateTime(2013, 11, 15), question.Date);
      Assert.Equal(1366, question.SessionCode);
      Assert.Equal(27, question.Code);
      Assert.Equal(1299, question.StartLine);
      Assert.Equal(1343, question.EndLine);

      question = questions.ElementAt(3);
      Assert.Equal(@"О проекте федерального закона № 228222-6 ""О внесении изменений в статью 11 Федерального закона ""О трудовых пенсиях в Российской Федерации"" (по вопросу о включении в страховой стаж для назначения пенсии периода получения высшего образования по очной форме обучения в государственных или муниципальных организациях высшего образования).", question.Name);
      Assert.Equal(new DateTime(2013, 11, 15), question.Date);
      Assert.Equal(1366, question.SessionCode);
      Assert.Equal(29, question.Code);
      Assert.Equal(3867, question.StartLine);
      Assert.Equal(5943, question.EndLine);

      question = questions.ElementAt(4);
      Assert.Equal(@"О проекте федерального закона № 193817-6 ""О внесении изменения в статью 19-1 Федерального закона ""Об обороте земель сельскохозяйственного назначения"" (в части продления срока осуществления органами местного самоуправления мероприятий по образованию земельных участков сельскохозяйственного назначения из земельных участков, находящихся в общей собственности).", question.Name);
      Assert.Equal(new DateTime(2013, 11, 12), question.Date);
      Assert.Equal(1364, question.SessionCode);
      Assert.Equal(40, question.Code);
      Assert.Equal(6225, question.StartLine);
      Assert.Equal(6278, question.EndLine);
    }

    private void TestRegionalAuthorities(IEnumerable<IAuthority> authorities)
    {
      Assertion.NotNull(authorities);

      Assert.True(authorities is List<RegionalAuthority>);
      Assert.NotEmpty(authorities);
      var authority = authorities.Single(x => x.Id == 6217700);
      Assert.Equal("Агинская Бурятская окружная Дума", authority.Name);
      Assert.False(authority.Active);
      Assert.Equal(new DateTime(1994, 1, 1), authority.FromDate);
      Assert.Equal(new DateTime(2008, 10, 12), authority.ToDate);
    }

    private void TestRequests(IEnumerable<IDeputyRequest> requests)
    {
      Assertion.NotNull(requests);

      Assert.True(requests is List<DeputyRequest>);
      Assert.NotEmpty(requests);
      var request = requests.First(x => x.Id == 14);
      Assert.Equal("Герасименко Н.Ф.", request.Initiator);
      Assert.Equal(new DateTime(2004, 11, 10), request.Date);
      Assert.Equal("О присоединении Российской Федерации к Рамочной конвенции Всемирной организации здравоохранения по борьбе против табака (N 1103-IV ГД от 10 ноября 2004 г.).", request.Name);
      Assert.Equal(new DateTime(2004, 11, 30), request.ControlDate);
      Assert.Equal(new DateTime(2004, 11, 12), request.SignDate);
      Assert.Equal("2.1.2-10/14", request.DocumentNumber);
      Assert.Equal("1103-IV ГД", request.ResolutionNumber);
      Assert.NotNull(request.Answer);
      Assert.Equal(99100416, request.Signer.Id);
      Assert.Equal("Чилингаров Артур Николаевич", request.Signer.Name);
      Assert.Equal(3, request.Addressee.Id);
      Assert.Equal(@"Председателю Правительства РФ\М.Е. Фрадкову", request.Addressee.Name);
    }

    private void TestStages(IEnumerable<IPhaseStage> stages)
    {
      Assertion.NotNull(stages);

      Assert.True(stages is List<PhaseStage>);
      Assert.NotEmpty(stages);
      var stage = stages.Single(x => x.Id == 1);
      Assert.Equal("Внесение законопроекта в Государственную Думу", stage.Name);
      Assert.Equal(3, stage.Phases.Count());

      var phase = stage.Phases.ElementAt(0);
      Assert.Equal(1, phase.Id);
      Assert.Equal("Регистрация законопроекта и материалов к нему в САДД Государственной Думы", phase.Name);
      Assert.Equal(173, phase.Instance.Id);
      Assert.Equal("УДИО ГД", phase.Instance.Name);
      Assert.True(phase.Instance.Active);

      phase = stage.Phases.ElementAt(1);
      Assert.Equal(2, phase.Id);
      Assert.Equal("Прохождение законопроекта у Председателя Государственной Думы", phase.Name);
      Assert.Equal(174, phase.Instance.Id);
      Assert.Equal("Секретариат Председателя ГД", phase.Instance.Name);
      Assert.True(phase.Instance.Active);

      phase = stage.Phases.ElementAt(2);
      Assert.Equal(3, phase.Id);
      Assert.Equal("Регистрация законопроекта в Секретариате Совета Государственной Думы", phase.Name);
      Assert.Equal(175, phase.Instance.Id);
      Assert.Equal("Секретариат Совета ГД", phase.Instance.Name);
      Assert.True(phase.Instance.Active);
    }

    private void TestTopics(IEnumerable<ITopic> topics)
    {
      Assert.NotNull(topics);

      Assert.True(topics is List<Topic>);
      Assert.NotEmpty(topics);
      var topic = topics.Single(x => x.Id == 62701);
      Assert.Equal("Бюджетное, налоговое, финансовое законодательство", topic.Name);
    }
  }
}