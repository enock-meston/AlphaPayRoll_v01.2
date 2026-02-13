using AlphaAssurance.DataServices.Login;
using AlphaAssurance.DataServices.ParamSec;
using AlphaAssurance.DataServices.Report;
using Alphabankblazor.DataServices.HumanResource;
using AlphaPayRoll.Components;
using AlphaPayRoll.DataServices.AgentComReport;
using AlphaPayRoll.DataServices.AgRetCotisation;
using AlphaPayRoll.DataServices.AgRetPaymentMois;
using AlphaPayRoll.DataServices.CalculSalaire;
using AlphaPayRoll.DataServices.Contrat;
using AlphaPayRoll.DataServices.ContratModif;
using AlphaPayRoll.DataServices.ContratSusp;
using AlphaPayRoll.DataServices.Depart;
using AlphaPayRoll.DataServices.DonBase;
using AlphaPayRoll.DataServices.DonBase.TSc551BranchAndSubBranch;
using AlphaPayRoll.DataServices.Exercice;
using AlphaPayRoll.DataServices.GetHRCounts;
using AlphaPayRoll.DataServices.GetUserCounts;
using AlphaPayRoll.DataServices.Localisation;
using AlphaPayRoll.DataServices.Menus;
using AlphaPayRoll.DataServices.Mutation;
using AlphaPayRoll.DataServices.ParamSec;
using AlphaPayRoll.DataServices.Personnel_RIM2;
using AlphaPayRoll.DataServices.PostModif;
using AlphaPayRoll.DataServices.Promotion;
using AlphaPayRoll.DataServices.Qualification;
using AlphaPayRoll.DataServices.RubSalCompte;
using AlphaPayRoll.DataServices.Salaire;
using AlphaPayRoll.DataServices.SalProcess;
using AlphaPayRoll.DataServices.TCl550Branch;
using AlphaPayRoll.DataServices.TCl550Departement;
using AlphaPayRoll.DataServices.TCl550Deplom;
using AlphaPayRoll.DataServices.TCl550DomEtud;
using AlphaPayRoll.DataServices.TCl550Fonction;
using AlphaPayRoll.DataServices.TCl550MaritStatus;
using AlphaPayRoll.DataServices.TCl550NatIDType;
using AlphaPayRoll.DataServices.TCl550NivEtudId;
using AlphaPayRoll.DataServices.TCl550Sexe;
using AlphaPayRoll.DataServices.TCl550Status;
using AlphaPayRoll.DataServices.TCl550Universite;
using AlphaPayRoll.DataServices.TRH02Agent;
using AlphaPayRoll.DataServices.TRH055FAUTE;
using AlphaPayRoll.DataServices.TSL02AgDimAugmSal;
using AlphaPayRoll.DataServices.TSL02AgentRet;
using AlphaPayRoll.DataServices.TSL02AgHSup;
using AlphaPayRoll.DataServices.TSL02TracEvSal;
using AlphaPayRoll.DataServices.TSL03Traitem;
using AlphaPayRoll.DataServices.TSL03TraitemAv;
using AlphaPayRoll.DataServices.TSL04ArchivINSS;
using AlphaPayRoll.DataServices.TSL04ArchivIPR;
using AlphaPayRoll.DataServices.TSL09ImputPay;
using AlphaPayRoll.DataServices.TSL550TpDimAugSal;
using AlphaPayRoll.DataServices.TSL550TPHSup;
using AlphaPayRoll.DataServices.TSto551EventIn;
using AlphaPayRoll.DataServices.TxDAT;
using AlphaPayRoll.DataServices.TypeCongCircons;
using AlphaPayRoll.DataServices.TypeSalaire;
using AlphaPayRoll.FAuthentication;
using AlphaPayRoll.StringCon;
using Blazored.SessionStorage;
using CongeRequest.DataService.CongeRequestF;
using HRProject.DataService.PlanningCongeFord;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using PayLibrary.AgRegAugmBase;
using PayLibrary.CalculSalaire;
using PayLibrary.Cl550Branch;
using PayLibrary.CongCircRequest;
using PayLibrary.CongeRequestF;
using PayLibrary.Contrat;
using PayLibrary.ContratModif;
using PayLibrary.ContratSusp;
using PayLibrary.Depart;
using PayLibrary.DonIntialMois;
using PayLibrary.Exercice;
using PayLibrary.Faute;
using PayLibrary.FauteTRH055;
using PayLibrary.GetHRCounts;
using PayLibrary.GetUserCounts;
using PayLibrary.Gravite;
using PayLibrary.InterfParamSec;
using PayLibrary.InterfPrmDonBase;
using PayLibrary.IReport;
using PayLibrary.Localisation;
using PayLibrary.ParamDonBase.TSc551BranchAndSubBranch;
using PayLibrary.Permission;
using PayLibrary.Personnel_RIM2;
using PayLibrary.PlanningConge;
using PayLibrary.PostModif;
using PayLibrary.Promotion;
using PayLibrary.Qualification;
using PayLibrary.RubSalCompte;
using PayLibrary.Saction;
using PayLibrary.Salaire;
using PayLibrary.SalProcess;
using PayLibrary.TCl550Departement;
using PayLibrary.TCl550Deplom;
using PayLibrary.TCl550DomEtud;
using PayLibrary.TCl550Fonction;
using PayLibrary.TCl550MaritStatus;
using PayLibrary.TCl550NatIDType;
using PayLibrary.TCl550NivEtudId;
using PayLibrary.TCl550Sexe;
using PayLibrary.TCl550Status;
using PayLibrary.TCl550Universite;
using PayLibrary.TCl550User;
using PayLibrary.TCt550TpTransTout;
using PayLibrary.Training;
using PayLibrary.TrainingField;
using PayLibrary.TRH02Agent;
using PayLibrary.TRH550TypeSalaire;
using PayLibrary.TSL02AgDimAugmSal;
using PayLibrary.TSL02AgentRet;
using PayLibrary.TSL02AgHSup;
using PayLibrary.TSL02TracEvSal;
using PayLibrary.TSL03Traitem;
using PayLibrary.TSL03TraitemAv;
using PayLibrary.TSL04ArchivINSS;
using PayLibrary.TSL04ArchivIPR;
using PayLibrary.TSL09ImputPay;
using PayLibrary.TSL550TpDimAugSal;
using PayLibrary.TSL550TPHSup;
using PayLibrary.TSto551EventIn;
using PayLibrary.TxDAT;
using PayLibrary.TypeCongCircons;
using PayLibrary.TypeSaction;
using static AlphaPayRoll.DataServices.TCl550User.TCl550UserServices;
using static PayAPI.RepServices.AgentComBranchService;
using static PayAPI.RepServices.AgentComListPrimeService;
using static PayAPI.RepServices.AgentComListPrimeVerifService;
using static PayAPI.RepServices.AgentComSubBranchService;
using static PayAPI.RepServices.SuperviseurZonervice;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("ApiConnection");
ClassConString.sConnectionString = connectionString;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddServerSideBlazor(); // aaded
// ADD THESE LINES FOR MUDBLAZOR
builder.Services.AddMudServices();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ClasAuthenticationStatProv>();
builder.Services.AddScoped<ClasAuthenticationStatProv>();

//string sUrl = "http://192.168.1.227/hrtestapi/";

string sUrl = "http://localhost:48866/";
//string sUrl = "http://192.168.1.221/payapi/";
//string sUrl = "http://192.168.1.221/leaveapi/";



builder.Services.AddBlazoredSessionStorage();

builder.Services.AddHttpClient<ITRH02Agent, TRH02AgentService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL02AgentRet, TSL02AgentRetService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCl550MaritStatus, TCl550MaritStatusService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCl550Deplom, TCl550DeplomService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL03Traitem, TSL03TraitemService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL03TraitemAv, TSL03TraitemAvService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL04ArchivINSS, TSL04ArchivINSSService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL04ArchivIPR, TSL04ArchivIPRService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL09ImputPay, TSL09ImputPayService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSto551EventIn, TSto551EventInService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCl550Branch, TCl550BranchService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCl550Departement, TCl550DepartementServise>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCl550Fonction, TCl550FonctionServise>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCl550NivEtudId, TCl550NivEtudIdService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCl550DomEtud, TCl550DomEtudService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCl550Universite, TCl550UniversiteService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCl550Status, TCl550StatusService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCl550User, TCl550UserService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCl550Sexe, TCl550SexeService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL550TPHSup, TSL550TPHSupService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL550TpDimAugSal, TSL550TpDimAugSalService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL02TracEvSal, TSL02TracEvSalService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL02AgHSup, TSL02AgHSupService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL02AgDimAugmSal, TSL02AgDimAugmSalService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL02AgRetPayment, TSL02AgDimAugmBaseService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<IUserLogin, UserLoginService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSc551User, TSc551UserService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITabPrmNivOne, TabPrmNivOneService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSc551SubMenu, SubMenuSevice>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL550Exercice, ExerciceService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL00Process, SalProcessService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL02AgRetCotis, TSL02AgRetCotisService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL02AgRegAugmMois, TSL02AgRegAugmMoisService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL02AgRetPaymentMois, TSL02AgRetPaymentMoisService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL02AgRetOccasMois, TSL02AgRetOccasMoisService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL02AgRetCotisMois, TSL02AgRetCotisMoisService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITVeh99Rapport, TVeh99RapportService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSl550RubSalCompte, TSl550RubSalCompteService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<IPersonnel_RIM2, Personnel_RIM2Service>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<IQualification, QualificationService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<IDepart, DepartService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCl550NatIDType, TCl550NatIDTypeService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<IClasContrat, ContratService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<IAgentComListPrimeService, AgentComReportService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSc551SubBranch, TCl550SubBranchService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<AgentComPrimeLoadService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<IAgentComListBranchService, AnnexeDonBranchService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<IAgentComListSubBranchService, AnnexeDonSubBranchService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<IAgentComListPrimeVerifService, AgentComReportVerifService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ISuperviseurZoneService, AgentComDonZoneService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ICalculerSalaire, CalculSalaireService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITHRPlanningConge, PlanningCongeService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITHRCongCircRequest, CongeRequestsService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITHRCongCircRequestNew, THRCongCircRequestService>(t => { t.BaseAddress = new Uri(sUrl); });

//=============Olivier Addition MudBlazor & SessionService =================//
builder.Services.AddHttpClient<ITRH03Training, TRH03TrainingService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITRH04FAUTE, TRH04FAUTEService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITRH055FAUTE, TRH055FAUTEService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITRH05Saction, TRH05SactionService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITRH031TrainingField, TRH031TrainingFieldService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITRH051TypeSaction, TRH051TypeSactionService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITRH042Gravite, TRH042GraviteService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITRH05Permission, TRH05PermissionService>(t => { t.BaseAddress = new Uri(sUrl); });

//en
builder.Services.AddHttpClient<ITRH05Mutation, TRH05MutationService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITRH05Localisation, TRH05LocalisationService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITHR05ContratModif, THR05ContratModifService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITRH05PostModif, TRH05PostModifService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITRH05Promotion, TRH05PromotionService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSL02Salaire, TSL02SalaireService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITRH550TypeSalaire, TRH550TypeSalaireService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<IClassGetHRCounts, ClassGetHRCountsService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<IClassGetAgentCounts, ClassGetAgentCountsService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITRH03ContratSusp, TRH03ContratSuspService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITRH051TypeCongCircons, TRH051TypeCongCirconsService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCt550TpTransTout, TCt550TpTransToutService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITCpt050TxDAT, TCpt050TxDATService>(t => { t.BaseAddress = new Uri(sUrl); });

builder.Services.AddHttpClient<ITSc551BranchDir, TSc551BranchDirService>(t => { t.BaseAddress = new Uri(sUrl); });
builder.Services.AddHttpClient<ITSc551SubBranchDir, TSc551SubBranchDirService>(t => { t.BaseAddress = new Uri(sUrl); });

builder.Services.AddSingleton<UserAccountService>();


builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseDeveloperExceptionPage(); // aade
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
