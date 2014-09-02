using System;
using System.Web;
using System.Web.Optimization;

namespace GoTracker
{
    public class BundleConfig
    {
        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
                throw new ArgumentNullException("ignoreList");
            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();
            AddDefaultIgnorePatterns(bundles.IgnoreList);
            
            //Styles

            bundles.Add(new StyleBundle("~/Template/Basic/css").Include(
                "~/Content/Template/css/styles.css").Include(
                "~/Content/Template/css/magicsuggest.css"));

            //Javascripts

            //Basic Scripts
            bundles.Add(new ScriptBundle("~/Template/Basic/js").Include(
                "~/Content/Template/js/vendors/modernizr/modernizr.custom.js"));

             //Jquery
            bundles.Add(new ScriptBundle("~/Template/JQuery").Include(
                "~/Content/Template/js/vendors/jquery/jquery.min.js"));

            //JqueryUi
            bundles.Add(new ScriptBundle("~/Template/JQueryUi").Include(
                
                "~/Content/Template/js/vendors/jquery/jquery-ui.min.js",
                "~/Content/Template/js/vendors/touch-punch/jquery.ui.touch-punch.min.js"));

            //Fullscreen
            bundles.Add(new ScriptBundle("~/Template/Fullscreen").Include(
                "~/Content/Template/js/vendors/fullscreen/screenfull.min.js"));
            
            //Nanoscroller
            bundles.Add(new ScriptBundle("~/Template/Nanoscroller").Include(
                "~/Content/Template/js/vendors/nanoscroller/jquery.nanoscroller.min.js"));

            //Sparkline
            bundles.Add(new ScriptBundle("~/Template/Sparkline").Include(
                "~/Content/Template/js/vendors/sparkline/jquery.sparkline.min.js"));

            //HorizontalDropdown
            bundles.Add(new ScriptBundle("~/Template/HorizontalDropdown").Include(
                "~/Content/Template/js/vendors/horisontal/cbpHorizontalSlideOutMenu.js", 
                "~/Content/Template/js/vendors/classie/classie.js"));

            //PowerWidgets
            bundles.Add(new ScriptBundle("~/Template/PowerWidgets").Include(
                "~/Content/Template/js/vendors/powerwidgets/powerwidgets.js"));

            //FlotChart
            bundles.Add(new ScriptBundle("~/Template/FlotChart").Include(
                "~/Content/Template/js/vendors/flotchart/jquery.flot.min.js", 
                "~/Content/Template/js/vendors/flotchart/jquery.flot.stack.min.js", 
                "~/Content/Template/js/vendors/flotchart/jquery.flot.categories.min.js", 
                "~/Content/Template/js/vendors/flotchart/jquery.flot.time.min.js", 
                "~/Content/Template/js/vendors/flotchart/jquery.flot.resize.min.js", 
                "~/Content/Template/js/vendors/flotchart/jquery.flot.axislabels.js", 
                "~/Content/Template/js/vendors/flotchart/jquery.flot-tooltip.js", 
                "~/Content/Template/js/vendors/flotchart/jquery.flot.pie.min.js"));

            //Bootstrap
            bundles.Add(new ScriptBundle("~/Template/Bootstrap").Include(
                "~/Content/Template/js/vendors/bootstrap/bootstrap.min.js"));

            //ToDo
            bundles.Add(new ScriptBundle("~/Template/ToDo").Include(
                "~/Content/Template/js/vendors/todos/todos.js"));

            //MainApp
            bundles.Add(new ScriptBundle("~/Template/MainApp").Include(
                "~/Content/Template/js/scripts.js"));

            //Google Maps
            bundles.Add(new ScriptBundle("~/Template/GoogleMaps").Include(
               "~/Content/Template/js/vendors/gmap/jquery.gmap.min.js"));
                
            // Forms
             bundles.Add(new ScriptBundle("~/Template/Forms").Include(
            "~/Content/Template/js/vendors/forms/jquery.form.min.js",
            "~/Content/Template/js/vendors/forms/jquery.validate.min.js",
            "~/Content/Template/js/vendors/forms/jquery.maskedinput.min.js",
            "~/Content/Template/js/vendors/jquery-steps/jquery.steps.min.js"));

             bundles.Add(new ScriptBundle("~/Template/Knockout").Include(
            "~/scripts/knockout-3.0.0.js",
            "~/scripts/knockout.combobox-1.0.71.0.js",
            "~/scripts/knockout.mapping-latest.js",
            "~/scripts/knockout.pager.js",
            "~/scripts/knockout.simpleGrid.3.0.js",
            "~/scripts/magicsuggest.js"));

        }
    }
}