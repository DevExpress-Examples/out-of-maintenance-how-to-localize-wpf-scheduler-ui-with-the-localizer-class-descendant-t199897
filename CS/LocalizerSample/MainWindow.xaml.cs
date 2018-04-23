using DevExpress.Xpf.Scheduler;
using System;

namespace LocalizerSample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DevExpress.Xpf.Ribbon.DXRibbonWindow {
        public MainWindow() {
            InitializeComponent();

        }

        #region #CustomLocalizer
        static MainWindow() {
            SchedulerControlLocalizer.Active = new CustomSchedulerLocalizer();
        }

        class CustomSchedulerLocalizer : SchedulerControlLocalizer {
            // Modify the specified caption.
            public override string GetLocalizedString(DevExpress.Xpf.Scheduler.SchedulerControlStringId id) {
                if (id ==SchedulerControlStringId.ButtonCaption_DismissAll)
                    return "42";
                else
                    return base.GetLocalizedString(id);
            }
            // Localize UI strings. 
            // Note that not all strings can be translated with Localizer classes. Use satellite assemblies in this situation. 
            protected override void PopulateStringTable() {
                //base.PopulateStringTable();
                foreach (SchedulerControlStringId s in Enum.GetValues(typeof(SchedulerControlStringId))) {
                    AddString(s, Enum.GetName(typeof(SchedulerControlStringId), s));
                }
            }
        }
        #endregion #CustomLocalizer

    }
}
