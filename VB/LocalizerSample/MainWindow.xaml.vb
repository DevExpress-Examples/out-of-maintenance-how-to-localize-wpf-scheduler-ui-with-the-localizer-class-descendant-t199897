Imports DevExpress.Xpf.Scheduler
Imports System

Namespace LocalizerSample
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits DevExpress.Xpf.Ribbon.DXRibbonWindow

        Public Sub New()
            InitializeComponent()

        End Sub

        #Region "#CustomLocalizer"
        Shared Sub New()
            SchedulerControlLocalizer.Active = New CustomSchedulerLocalizer()
        End Sub

        Private Class CustomSchedulerLocalizer
            Inherits SchedulerControlLocalizer

            ' Modify the specified caption.
            Public Overrides Function GetLocalizedString(ByVal id As DevExpress.Xpf.Scheduler.SchedulerControlStringId) As String
                If id = SchedulerControlStringId.ButtonCaption_DismissAll Then
                    Return "42"
                Else
                    Return MyBase.GetLocalizedString(id)
                End If
            End Function
            ' Localize UI strings. 
            ' Note that not all strings can be translated with Localizer classes. Use satellite assemblies in this situation. 
            Protected Overrides Sub PopulateStringTable()
                'base.PopulateStringTable();
                For Each s As SchedulerControlStringId In System.Enum.GetValues(GetType(SchedulerControlStringId))
                    AddString(s, System.Enum.GetName(GetType(SchedulerControlStringId), s))
                Next s
            End Sub
        End Class
        #End Region ' #CustomLocalizer

    End Class
End Namespace
