using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.Migrations;
using Umbraco.Core.Persistence.SqlSyntax;

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
