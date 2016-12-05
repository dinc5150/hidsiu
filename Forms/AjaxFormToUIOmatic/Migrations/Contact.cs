using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.Migrations;
using Umbraco.Core.Persistence.SqlSyntax;


public class ContactMigration{
 public static void HandleMigration(){
     
    const string productName = "Contact";
    var currentVersion = new SemVersion(0, 0, 0);

    // get all migrations for "Contact" already executed
    var migrations = ApplicationContext.Current.Services.MigrationEntryService.GetAll(productName);

    // get the latest migration for "Statistics" executed
    var latestMigration = migrations.OrderByDescending(x => x.Version).FirstOrDefault();

    if (latestMigration != null)
        currentVersion = latestMigration.Version;

    var targetVersion = new SemVersion(1, 0, 0);
    if (targetVersion == currentVersion)
        return;

    var migrationsRunner = new MigrationRunner(
      ApplicationContext.Current.Services.MigrationEntryService,
      ApplicationContext.Current.ProfilingLogger.Logger,
      currentVersion,
      targetVersion,
      productName);

    try {
        migrationsRunner.Execute(UmbracoContext.Current.Application.DatabaseContext.Database);
    } catch (Exception e) {
        LogHelper.Error<umbracoCustomEvents>("Error running Migration migration", e);
    }
     
 }
}

    [Migration("1.0.0", 1, "Contact")]
    public class ContactMigration_1_0_0 : MigrationBase {
        private readonly UmbracoDatabase _database = ApplicationContext.Current.DatabaseContext.Database;
        private readonly DatabaseSchemaHelper _schemaHelper;

        public CreatePacmanTable(ISqlSyntaxProvider sqlSyntax, ILogger logger) : base(sqlSyntax, logger)
    {
            _schemaHelper = new DatabaseSchemaHelper(_database, logger, sqlSyntax);
        }

        public override void Up() {
            _schemaHelper.CreateTable<Contact>(false);
        }

        public override void Down() {
            _schemaHelper.DropTable<Contact>();
        }
    }
