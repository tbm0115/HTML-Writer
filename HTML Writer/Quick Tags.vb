Public Module Quick_Tags
  ''' <summary>
  ''' Represents the HTML Markup for a generic "To Top" link. This markup is styled to hover in the upper right corner of the page.
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function ToTop_Anchor() As String
    Dim a As String
    a = New HTMLWriter.HTMLAnchor("Top", "totopanchor", , , , New AttributeList({"position", "top", "right"}, {"absolute", "0", "0"}, True)).ToString
    a += New HTMLWriter.HTMLAnchor("Top", , "#totopanchor", , , New AttributeList({"position", "top", "right"}, {"fixed", "0", "0"}, True)).ToString
    Return a
  End Function

  ''' <summary>
  ''' Represents the HTML Markup for a generic "Overlay" control consisting of two Divs, two Anchors, and any other specified HTML Markup
  ''' </summary>
  ''' <remarks></remarks>
  Public Class Overlay
    Private _overlay As HTMLWriter.HTMLDiv
    Private _container As HTMLWriter.HTMLDiv
    Private _showAnchor As HTMLWriter.HTMLAnchor
    Private _closeAnchor As HTMLWriter.HTMLAnchor
    Private _containerid, _showlabel, _closelabel As String
    Public Property OverlayDiv As HTMLWriter.HTMLDiv
      Get
        Return _overlay
      End Get
      Set(value As HTMLWriter.HTMLDiv)
        _overlay = value
      End Set
    End Property
    Public Property ContainerDiv As HTMLWriter.HTMLDiv
      Get
        Return _container
      End Get
      Set(value As HTMLWriter.HTMLDiv)
        _container = value
      End Set
    End Property
    Public Property ShowAnchor As HTMLWriter.HTMLAnchor
      Get
        Return _showAnchor
      End Get
      Set(value As HTMLWriter.HTMLAnchor)
        _showAnchor = value
      End Set
    End Property
    Public Property CloseAnchor As HTMLWriter.HTMLAnchor
      Get
        Return _closeAnchor
      End Get
      Set(value As HTMLWriter.HTMLAnchor)
        _closeAnchor = value
      End Set
    End Property
    Public Property ContainerID As String
      Get
        Return _containerid
      End Get
      Set(value As String)
        _containerid = value
      End Set
    End Property
    Public Property ShowLabel As String
      Get
        Return _showlabel
      End Get
      Set(value As String)
        _showlabel = value
      End Set
    End Property
    Public Property CloseLabel As String
      Get
        Return _closelabel
      End Get
      Set(value As String)
        _closelabel = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Dim tmpo As New HTMLWriter.HTMLDiv(_overlay.InnerHTML, _overlay.AttributeList)
      Dim tmpc As New HTMLWriter.HTMLDiv(_container.InnerHTML, _container.AttributeList)
      tmpc.AppendDiv(_closeAnchor.ToString)
      tmpo.AppendDiv(tmpc.ToString)
      Return _showAnchor.ToString & vbLf & tmpo.ToString
    End Function

    Public Sub New(ByVal ContainerID As String, ByVal ShowLabel As String, ByVal CloseLabel As String, Optional ByVal RawHTML As String = "",
                   Optional ByVal OverlayDiv As HTMLWriter.HTMLDiv = Nothing, Optional ByVal ContainerDiv As HTMLWriter.HTMLDiv = Nothing,
                    Optional ByVal ShowAnchor As HTMLWriter.HTMLAnchor = Nothing, Optional ByVal CloseAnchor As HTMLWriter.HTMLAnchor = Nothing,
                    Optional ByVal OverlayStyle As AttributeList = Nothing, Optional ByVal ContainerStyle As AttributeList = Nothing,
                    Optional ByVal ShowStyle As AttributeList = Nothing, Optional CloseStyle As AttributeList = Nothing)
      _containerid = ContainerID
      _showlabel = ShowLabel
      _closelabel = CloseLabel
      If Not IsNothing(OverlayDiv) Then _overlay = OverlayDiv Else _overlay = New HTMLWriter.HTMLDiv(, OverlayStyle)
      If Not IsNothing(ContainerStyle) Then
        ContainerStyle.AddAttribute(New AttributeList.AttributeItem("id", ContainerID))
      Else
        ContainerStyle = New AttributeList({"id"}, {ContainerID}, False)
      End If
      If Not IsNothing(ContainerDiv) Then _container = ContainerDiv Else _container = New HTMLWriter.HTMLDiv(, ContainerStyle)
      If Not IsNothing(ShowAnchor) Then _showAnchor = ShowAnchor Else _showAnchor = New HTMLWriter.HTMLAnchor(ShowLabel, , , , , ShowStyle)
      If Not IsNothing(CloseAnchor) Then _closeAnchor = CloseAnchor Else _closeAnchor = New HTMLWriter.HTMLAnchor(CloseLabel, , , , , CloseStyle)
      _showAnchor.AttributeList.AddAttribute(New AttributeList.AttributeItem("onclick",
                                                                             "overlay(document.getElementById('" & _containerid & "').parentElement);"))
      _closeAnchor.AttributeList.AddAttribute(New AttributeList.AttributeItem("onclick",
                                                                              "overlay(this.parentElement.parentElement);"))
      SetOverlay(RawHTML)
    End Sub
    Public Sub New(ByVal ContainerID As String, ByVal ShowLabel As String, ByVal CloseLabel As String, Optional ByVal RawHTML As String = "",
                   Optional ByVal OverlayDiv As HTMLWriter.HTMLDiv = Nothing, Optional ByVal ContainerDiv As HTMLWriter.HTMLDiv = Nothing,
                    Optional ByVal ShowAnchor As HTMLWriter.HTMLAnchor = Nothing, Optional ByVal CloseAnchor As HTMLWriter.HTMLAnchor = Nothing,
                    Optional ByVal OverlayClass As String = "Overlay", Optional ByVal ContainerClass As String = "",
                    Optional ByVal ShowClass As String = "", Optional CloseClass As String = "")
      _containerid = ContainerID
      _showlabel = ShowLabel
      _closelabel = CloseLabel
      If Not IsNothing(OverlayDiv) Then _overlay = OverlayDiv Else _overlay = New HTMLWriter.HTMLDiv(, New AttributeList({"class"}, {OverlayClass}, False))
      If Not IsNothing(ContainerDiv) Then _container = ContainerDiv Else _container = New HTMLWriter.HTMLDiv(, New AttributeList({"class"}, {ContainerClass}, False))
      If Not IsNothing(ShowAnchor) Then _showAnchor = ShowAnchor Else _showAnchor = New HTMLWriter.HTMLAnchor(ShowLabel, , , , , New AttributeList({"class"}, {ShowClass}))
      If Not IsNothing(CloseAnchor) Then _closeAnchor = CloseAnchor Else _closeAnchor = New HTMLWriter.HTMLAnchor(CloseLabel, , , , , New AttributeList({"class"}, {CloseClass}))
      _showAnchor.AttributeList.AddAttribute(New AttributeList.AttributeItem("onclick",
                                                                             "overlay(document.getElementById('" & _containerid & "').parentElement);"))
      _closeAnchor.AttributeList.AddAttribute(New AttributeList.AttributeItem("onclick",
                                                                              "overlay(this.parentElement.parentElement);"))
      SetOverlay(RawHTML)
    End Sub

    Public Sub SetOverlay(ByVal RawHTML As String)
      _container.SetDiv(RawHTML)
    End Sub
    Public Sub AppendOverlay(ByVal ExtraHTML As String)
      _container.AppendDiv(ExtraHTML)
    End Sub
  End Class

End Module
