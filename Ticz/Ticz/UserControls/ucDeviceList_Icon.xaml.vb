﻿' The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

Public NotInheritable Class ucDeviceList_Icon
    Inherits UserControl

    Public Property RoomViewModel As RoomViewModel

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        AddHandler DataContextChanged, Sub(s, e)
                                           WriteToDebug("ucDeviceList_Icon - DataContextChanged", "")
                                           RoomViewModel = CType(DataContext, RoomViewModel)
                                       End Sub

        ' Add any initialization after the InitializeComponent() call.

    End Sub

End Class
