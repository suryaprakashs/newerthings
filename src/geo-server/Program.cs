using geo_server.Redis;
using geo_server.Services;
using Geo;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.InstanceName = builder.Configuration.GetValue<string>("redis:name");
    options.Configuration = builder.Configuration.GetValue<string>("redis:host") + ":" + builder.Configuration.GetValue<string>("redis:port");
});

builder.Services.AddSingleton<RedisService>();
builder.Services.AddSession();

builder.WebHost.ConfigureKestrel((context, options) =>
  {
      options.Listen(IPAddress.Any, 5129, listenOptions =>
      {
          listenOptions.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2;
      });
  });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSession();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<GeoCountryService>();
});

SeedData();

app.Run();


void SeedData()
{
    var response = new List<Country>();
    response.Add(new Country { Id = "AF", Name = "Afghanistan" });
    response.Add(new Country { Id = "AL", Name = "Albania" });
    response.Add(new Country { Id = "DZ", Name = "Algeria" });
    response.Add(new Country { Id = "AS", Name = "American Samoa" });
    response.Add(new Country { Id = "AD", Name = "Andorra" });
    response.Add(new Country { Id = "AO", Name = "Angola" });
    response.Add(new Country { Id = "AI", Name = "Anguilla" });
    response.Add(new Country { Id = "AQ", Name = "Antarctica" });
    response.Add(new Country { Id = "AG", Name = "Antigua And Barbuda" });
    response.Add(new Country { Id = "AR", Name = "Argentina" });
    response.Add(new Country { Id = "AM", Name = "Armenia" });
    response.Add(new Country { Id = "AW", Name = "Aruba" });
    response.Add(new Country { Id = "AU", Name = "Australia" });
    response.Add(new Country { Id = "AT", Name = "Austria" });
    response.Add(new Country { Id = "AZ", Name = "Azerbaijan" });
    response.Add(new Country { Id = "BS", Name = "Bahamas" });
    response.Add(new Country { Id = "BH", Name = "Bahrain" });
    response.Add(new Country { Id = "BD", Name = "Bangladesh" });
    response.Add(new Country { Id = "BB", Name = "Barbados" });
    response.Add(new Country { Id = "BY", Name = "Belarus" });
    response.Add(new Country { Id = "BE", Name = "Belgium" });
    response.Add(new Country { Id = "BZ", Name = "Belize" });
    response.Add(new Country { Id = "BJ", Name = "Benin" });
    response.Add(new Country { Id = "BM", Name = "Bermuda" });
    response.Add(new Country { Id = "BT", Name = "Bhutan" });
    response.Add(new Country { Id = "BO", Name = "Bolivia" });
    response.Add(new Country { Id = "BA", Name = "Bosnia And Herzegovina" });
    response.Add(new Country { Id = "BW", Name = "Botswana" });
    response.Add(new Country { Id = "BV", Name = "Bouvet Island" });
    response.Add(new Country { Id = "BR", Name = "Brazil" });
    response.Add(new Country { Id = "IO", Name = "British Indian Ocean Territory" });
    response.Add(new Country { Id = "BN", Name = "Brunei Darussalam" });
    response.Add(new Country { Id = "BG", Name = "Bulgaria" });
    response.Add(new Country { Id = "BF", Name = "Burkina Faso" });
    response.Add(new Country { Id = "BI", Name = "Burundi" });
    response.Add(new Country { Id = "KH", Name = "Cambodia" });
    response.Add(new Country { Id = "CM", Name = "Cameroon" });
    response.Add(new Country { Id = "CA", Name = "Canada" });
    response.Add(new Country { Id = "CV", Name = "Cape Verde" });
    response.Add(new Country { Id = "KY", Name = "Cayman Islands" });
    response.Add(new Country { Id = "CF", Name = "Central African Republic" });
    response.Add(new Country { Id = "TD", Name = "Chad" });
    response.Add(new Country { Id = "CL", Name = "Chile" });
    response.Add(new Country { Id = "CN", Name = "China" });
    response.Add(new Country { Id = "CX", Name = "Christmas Island" });
    response.Add(new Country { Id = "CC", Name = "Cocos (keeling) Islands" });
    response.Add(new Country { Id = "CO", Name = "Colombia" });
    response.Add(new Country { Id = "KM", Name = "Comoros" });
    response.Add(new Country { Id = "CG", Name = "Congo" });
    response.Add(new Country { Id = "CD", Name = "Congo, The Democratic Republic Of The" });
    response.Add(new Country { Id = "CK", Name = "Cook Islands" });
    response.Add(new Country { Id = "CR", Name = "Costa Rica" });
    response.Add(new Country { Id = "CI", Name = "Cote D'ivoire" });
    response.Add(new Country { Id = "HR", Name = "Croatia" });
    response.Add(new Country { Id = "CU", Name = "Cuba" });
    response.Add(new Country { Id = "CY", Name = "Cyprus" });
    response.Add(new Country { Id = "CZ", Name = "Czech Republic" });
    response.Add(new Country { Id = "DK", Name = "Denmark" });
    response.Add(new Country { Id = "DJ", Name = "Djibouti" });
    response.Add(new Country { Id = "DM", Name = "Dominica" });
    response.Add(new Country { Id = "DO", Name = "Dominican Republic" });
    response.Add(new Country { Id = "TP", Name = "East Timor" });
    response.Add(new Country { Id = "EC", Name = "Ecuador" });
    response.Add(new Country { Id = "EG", Name = "Egypt" });
    response.Add(new Country { Id = "SV", Name = "El Salvador" });
    response.Add(new Country { Id = "GQ", Name = "Equatorial Guinea" });
    response.Add(new Country { Id = "ER", Name = "Eritrea" });
    response.Add(new Country { Id = "EE", Name = "Estonia" });
    response.Add(new Country { Id = "ET", Name = "Ethiopia" });
    response.Add(new Country { Id = "FK", Name = "Falkland Islands (malvinas)" });
    response.Add(new Country { Id = "FO", Name = "Faroe Islands" });
    response.Add(new Country { Id = "FJ", Name = "Fiji" });
    response.Add(new Country { Id = "FI", Name = "Finland" });
    response.Add(new Country { Id = "FR", Name = "France" });
    response.Add(new Country { Id = "GF", Name = "French Guiana" });
    response.Add(new Country { Id = "PF", Name = "French Polynesia" });
    response.Add(new Country { Id = "TF", Name = "French Southern Territories" });
    response.Add(new Country { Id = "GA", Name = "Gabon" });
    response.Add(new Country { Id = "GM", Name = "Gambia" });
    response.Add(new Country { Id = "GE", Name = "Georgia" });
    response.Add(new Country { Id = "DE", Name = "Germany" });
    response.Add(new Country { Id = "GH", Name = "Ghana" });
    response.Add(new Country { Id = "GI", Name = "Gibraltar" });
    response.Add(new Country { Id = "GR", Name = "Greece" });
    response.Add(new Country { Id = "GL", Name = "Greenland" });
    response.Add(new Country { Id = "GD", Name = "Grenada" });
    response.Add(new Country { Id = "GP", Name = "Guadeloupe" });
    response.Add(new Country { Id = "GU", Name = "Guam" });
    response.Add(new Country { Id = "GT", Name = "Guatemala" });
    response.Add(new Country { Id = "GN", Name = "Guinea" });
    response.Add(new Country { Id = "GW", Name = "Guinea-bissau" });
    response.Add(new Country { Id = "GY", Name = "Guyana" });
    response.Add(new Country { Id = "HT", Name = "Haiti" });
    response.Add(new Country { Id = "HM", Name = "Heard Island And Mcdonald Islands" });
    response.Add(new Country { Id = "VA", Name = "Holy See (vatican City State)" });
    response.Add(new Country { Id = "HN", Name = "Honduras" });
    response.Add(new Country { Id = "HK", Name = "Hong Kong" });
    response.Add(new Country { Id = "HU", Name = "Hungary" });
    response.Add(new Country { Id = "IS", Name = "Iceland" });
    response.Add(new Country { Id = "IN", Name = "India" });
    response.Add(new Country { Id = "ID", Name = "Indonesia" });
    response.Add(new Country { Id = "IR", Name = "Iran, Islamic Republic Of" });
    response.Add(new Country { Id = "IQ", Name = "Iraq" });
    response.Add(new Country { Id = "IE", Name = "Ireland" });
    response.Add(new Country { Id = "IL", Name = "Israel" });
    response.Add(new Country { Id = "IT", Name = "Italy" });
    response.Add(new Country { Id = "JM", Name = "Jamaica" });
    response.Add(new Country { Id = "JP", Name = "Japan" });
    response.Add(new Country { Id = "JO", Name = "Jordan" });
    response.Add(new Country { Id = "KZ", Name = "Kazakstan" });
    response.Add(new Country { Id = "KE", Name = "Kenya" });
    response.Add(new Country { Id = "KI", Name = "Kiribati" });
    response.Add(new Country { Id = "KP", Name = "Korea, Democratic People's Republic Of" });
    response.Add(new Country { Id = "KR", Name = "Korea, Republic Of" });
    response.Add(new Country { Id = "KV", Name = "Kosovo" });
    response.Add(new Country { Id = "KW", Name = "Kuwait" });
    response.Add(new Country { Id = "KG", Name = "Kyrgyzstan" });
    response.Add(new Country { Id = "LA", Name = "Lao People's Democratic Republic" });
    response.Add(new Country { Id = "LV", Name = "Latvia" });
    response.Add(new Country { Id = "LB", Name = "Lebanon" });
    response.Add(new Country { Id = "LS", Name = "Lesotho" });
    response.Add(new Country { Id = "LR", Name = "Liberia" });
    response.Add(new Country { Id = "LY", Name = "Libyan Arab Jamahiriya" });
    response.Add(new Country { Id = "LI", Name = "Liechtenstein" });
    response.Add(new Country { Id = "LT", Name = "Lithuania" });
    response.Add(new Country { Id = "LU", Name = "Luxembourg" });
    response.Add(new Country { Id = "MO", Name = "Macau" });
    response.Add(new Country { Id = "MK", Name = "Macedonia, The Former Yugoslav Republic Of" });
    response.Add(new Country { Id = "MG", Name = "Madagascar" });
    response.Add(new Country { Id = "MW", Name = "Malawi" });
    response.Add(new Country { Id = "MY", Name = "Malaysia" });
    response.Add(new Country { Id = "MV", Name = "Maldives" });
    response.Add(new Country { Id = "ML", Name = "Mali" });
    response.Add(new Country { Id = "MT", Name = "Malta" });
    response.Add(new Country { Id = "MH", Name = "Marshall Islands" });
    response.Add(new Country { Id = "MQ", Name = "Martinique" });
    response.Add(new Country { Id = "MR", Name = "Mauritania" });
    response.Add(new Country { Id = "MU", Name = "Mauritius" });
    response.Add(new Country { Id = "YT", Name = "Mayotte" });
    response.Add(new Country { Id = "MX", Name = "Mexico" });
    response.Add(new Country { Id = "FM", Name = "Micronesia, Federated States Of" });
    response.Add(new Country { Id = "MD", Name = "Moldova, Republic Of" });
    response.Add(new Country { Id = "MC", Name = "Monaco" });
    response.Add(new Country { Id = "MN", Name = "Mongolia" });
    response.Add(new Country { Id = "MS", Name = "Montserrat" });
    response.Add(new Country { Id = "ME", Name = "Montenegro" });
    response.Add(new Country { Id = "MA", Name = "Morocco" });
    response.Add(new Country { Id = "MZ", Name = "Mozambique" });
    response.Add(new Country { Id = "MM", Name = "Myanmar" });
    response.Add(new Country { Id = "NA", Name = "Namibia" });
    response.Add(new Country { Id = "NR", Name = "Nauru" });
    response.Add(new Country { Id = "NP", Name = "Nepal" });
    response.Add(new Country { Id = "NL", Name = "Netherlands" });
    response.Add(new Country { Id = "AN", Name = "Netherlands Antilles" });
    response.Add(new Country { Id = "NC", Name = "New Caledonia" });
    response.Add(new Country { Id = "NZ", Name = "New Zealand" });
    response.Add(new Country { Id = "NI", Name = "Nicaragua" });
    response.Add(new Country { Id = "NE", Name = "Niger" });
    response.Add(new Country { Id = "NG", Name = "Nigeria" });
    response.Add(new Country { Id = "NU", Name = "Niue" });
    response.Add(new Country { Id = "NF", Name = "Norfolk Island" });
    response.Add(new Country { Id = "MP", Name = "Northern Mariana Islands" });
    response.Add(new Country { Id = "NO", Name = "Norway" });
    response.Add(new Country { Id = "OM", Name = "Oman" });
    response.Add(new Country { Id = "PK", Name = "Pakistan" });
    response.Add(new Country { Id = "PW", Name = "Palau" });
    response.Add(new Country { Id = "PS", Name = "Palestinian Territory, Occupied" });
    response.Add(new Country { Id = "PA", Name = "Panama" });
    response.Add(new Country { Id = "PG", Name = "Papua New Guinea" });
    response.Add(new Country { Id = "PY", Name = "Paraguay" });
    response.Add(new Country { Id = "PE", Name = "Peru" });
    response.Add(new Country { Id = "PH", Name = "Philippines" });
    response.Add(new Country { Id = "PN", Name = "Pitcairn" });
    response.Add(new Country { Id = "PL", Name = "Poland" });
    response.Add(new Country { Id = "PT", Name = "Portugal" });
    response.Add(new Country { Id = "PR", Name = "Puerto Rico" });
    response.Add(new Country { Id = "QA", Name = "Qatar" });
    response.Add(new Country { Id = "RE", Name = "Reunion" });
    response.Add(new Country { Id = "RO", Name = "Romania" });
    response.Add(new Country { Id = "RU", Name = "Russian Federation" });
    response.Add(new Country { Id = "RW", Name = "Rwanda" });
    response.Add(new Country { Id = "SH", Name = "Saint Helena" });
    response.Add(new Country { Id = "KN", Name = "Saint Kitts And Nevis" });
    response.Add(new Country { Id = "LC", Name = "Saint Lucia" });
    response.Add(new Country { Id = "PM", Name = "Saint Pierre And Miquelon" });
    response.Add(new Country { Id = "VC", Name = "Saint Vincent And The Grenadines" });
    response.Add(new Country { Id = "WS", Name = "Samoa" });
    response.Add(new Country { Id = "SM", Name = "San Marino" });
    response.Add(new Country { Id = "ST", Name = "Sao Tome And Principe" });
    response.Add(new Country { Id = "SA", Name = "Saudi Arabia" });
    response.Add(new Country { Id = "SN", Name = "Senegal" });
    response.Add(new Country { Id = "RS", Name = "Serbia" });
    response.Add(new Country { Id = "SC", Name = "Seychelles" });
    response.Add(new Country { Id = "SL", Name = "Sierra Leone" });
    response.Add(new Country { Id = "SG", Name = "Singapore" });
    response.Add(new Country { Id = "SK", Name = "Slovakia" });
    response.Add(new Country { Id = "SI", Name = "Slovenia" });
    response.Add(new Country { Id = "SB", Name = "Solomon Islands" });
    response.Add(new Country { Id = "SO", Name = "Somalia" });
    response.Add(new Country { Id = "ZA", Name = "South Africa" });
    response.Add(new Country { Id = "GS", Name = "South Georgia And The South Sandwich Islands" });
    response.Add(new Country { Id = "ES", Name = "Spain" });
    response.Add(new Country { Id = "LK", Name = "Sri Lanka" });
    response.Add(new Country { Id = "SD", Name = "Sudan" });
    response.Add(new Country { Id = "SR", Name = "Suriname" });
    response.Add(new Country { Id = "SJ", Name = "Svalbard And Jan Mayen" });
    response.Add(new Country { Id = "SZ", Name = "Swaziland" });
    response.Add(new Country { Id = "SE", Name = "Sweden" });
    response.Add(new Country { Id = "CH", Name = "Switzerland" });
    response.Add(new Country { Id = "SY", Name = "Syrian Arab Republic" });
    response.Add(new Country { Id = "TW", Name = "Taiwan, Province Of China" });
    response.Add(new Country { Id = "TJ", Name = "Tajikistan" });
    response.Add(new Country { Id = "TZ", Name = "Tanzania, United Republic Of" });
    response.Add(new Country { Id = "TH", Name = "Thailand" });
    response.Add(new Country { Id = "TG", Name = "Togo" });
    response.Add(new Country { Id = "TK", Name = "Tokelau" });
    response.Add(new Country { Id = "TO", Name = "Tonga" });
    response.Add(new Country { Id = "TT", Name = "Trinidad And Tobago" });
    response.Add(new Country { Id = "TN", Name = "Tunisia" });
    response.Add(new Country { Id = "TR", Name = "Turkey" });
    response.Add(new Country { Id = "TM", Name = "Turkmenistan" });
    response.Add(new Country { Id = "TC", Name = "Turks And Caicos Islands" });
    response.Add(new Country { Id = "TV", Name = "Tuvalu" });
    response.Add(new Country { Id = "UG", Name = "Uganda" });
    response.Add(new Country { Id = "UA", Name = "Ukraine" });
    response.Add(new Country { Id = "AE", Name = "United Arab Emirates" });
    response.Add(new Country { Id = "GB", Name = "United Kingdom" });
    response.Add(new Country { Id = "US", Name = "United States" });
    response.Add(new Country { Id = "UM", Name = "United States Minor Outlying Islands" });
    response.Add(new Country { Id = "UY", Name = "Uruguay" });
    response.Add(new Country { Id = "UZ", Name = "Uzbekistan" });
    response.Add(new Country { Id = "VU", Name = "Vanuatu" });
    response.Add(new Country { Id = "VE", Name = "Venezuela" });
    response.Add(new Country { Id = "VN", Name = "Viet Nam" });
    response.Add(new Country { Id = "VG", Name = "Virgin Islands, British" });
    response.Add(new Country { Id = "VI", Name = "Virgin Islands, U.s." });
    response.Add(new Country { Id = "WF", Name = "Wallis And Futuna" });
    response.Add(new Country { Id = "EH", Name = "Western Sahara" });
    response.Add(new Country { Id = "YE", Name = "Yemen" });
    response.Add(new Country { Id = "ZM", Name = "Zambia" });
    response.Add(new Country { Id = "ZW", Name = "Zimbabwe" });

    var redisService = app.Services.GetRequiredService<RedisService>();
    redisService.Set("AllCountries", response);
}