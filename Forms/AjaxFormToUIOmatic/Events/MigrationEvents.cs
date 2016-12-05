using DM.Controllers;
using Semver;
using System;
using System.IO;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Persistence.Migrations;
using Umbraco.Core.Services;
using Umbraco.Web;

/// <summary>
/// Summary description for umbracoEvents
/// </summary>
public class MigrationEvents : ApplicationEventHandler {
    protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext) {
      //Need to trigger Migrations on startup
      ContactMigration.HandleMigration();
    }
}
