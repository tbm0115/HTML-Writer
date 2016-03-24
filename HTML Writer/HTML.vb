﻿Imports System.Drawing
Imports System.Text

Public Class HTMLWriter
  Private str_html As New StringBuilder

  ''' <summary>
  ''' Get/Set the condition of whether the HTMLWriter class should find and replace any invalid characteristics. Note that most HTML tags should be safe.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property SafeMode As Boolean
    Get
      Return _safeChars
    End Get
    Set(value As Boolean)
      _safeChars = value
    End Set
  End Property
  Public Property HTMLMarkup As String
    Get
      Return str_html.ToString
    End Get
    Set(value As String)
      If value.Contains("</html>") Then
        str_html = New StringBuilder
        str_html.Append(value)
      Else
        Throw New ApplicationException("{HTML}HTMLWriter: Cannot set 'HTMLMarkup' value without the '<html>' tag." + vbLf + "Cannot set to: '" + value + "'")
      End If
    End Set
  End Property
  Public Enum TargetType
    Blank
    Self
    Parent
    Top
    Frame
  End Enum
  Public Enum InputType
    iColor
    iDate
    iDateTime
    iDateTimeLocal
    iEmail
    iMonth
    iNumber
    iRange
    iSearch
    iTel
    iTime
    iUrl
    iWeek
    iButton
    iCheckBox
    iRadio
    iSubmit
    iText
    iPassword
  End Enum
  Public Overrides Function ToString() As String
    Return str_html.ToString
  End Function

  ''' <summary>
  ''' Creates a new instance of an HTML Document
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub New(Optional ByVal SafetyMode As Boolean = True)
    _safeChars = SafetyMode
    str_html = New StringBuilder
    str_html.Append("<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>")
  End Sub

  '' Series of methods to add markup to the current instance of an HTML Writer
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal RawHTML As String) As HTMLWriter
    If IsNothing(Writer.HTMLMarkup) Then
      'Set first html tag
      Writer.HTMLMarkup = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
    End If
    Writer.HTMLMarkup = Writer.HTMLMarkup.Replace("</html>", vbTab & RawHTML & vbLf & "</html>")
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLForm) As HTMLWriter
    If IsNothing(Writer.HTMLMarkup) Then
      'Set first html tag
      Writer.HTMLMarkup = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
    End If
    Writer.HTMLMarkup = Writer.HTMLMarkup.Replace("</html>", vbTab & HTMLObject.ToString & vbLf & "</html>")
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLHeader) As HTMLWriter
    If IsNothing(Writer.HTMLMarkup) Then
      'Set first html tag
      Writer.HTMLMarkup = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
    End If
    Writer.HTMLMarkup = Writer.HTMLMarkup.Replace("</html>", vbTab & HTMLObject.ToString & vbLf & "</html>")
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLTable) As HTMLWriter
    If IsNothing(Writer.HTMLMarkup) Then
      'Set first html tag
      Writer.HTMLMarkup = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
    End If
    Writer.HTMLMarkup = Writer.HTMLMarkup.Replace("</html>", vbTab & HTMLObject.ToString & vbLf & "</html>")
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLImageMap) As HTMLWriter
    If IsNothing(Writer.HTMLMarkup) Then
      'Set first html tag
      Writer.HTMLMarkup = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
    End If
    Writer.HTMLMarkup = Writer.HTMLMarkup.Replace("</html>", vbTab & HTMLObject.ToString & vbLf & "</html>")
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLList) As HTMLWriter
    If IsNothing(Writer.HTMLMarkup) Then
      'Set first html tag
      Writer.HTMLMarkup = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
    End If
    Writer.HTMLMarkup = Writer.HTMLMarkup.Replace("</html>", vbTab & HTMLObject.ToString & vbLf & "</html>")
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLImage) As HTMLWriter
    If IsNothing(Writer.HTMLMarkup) Then
      'Set first html tag
      Writer.HTMLMarkup = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
    End If
    Writer.HTMLMarkup = Writer.HTMLMarkup.Replace("</html>", vbTab & HTMLObject.ToString & vbLf & "</html>")
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLCanvas) As HTMLWriter
    If IsNothing(Writer.HTMLMarkup) Then
      'Set first html tag
      Writer.HTMLMarkup = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
    End If
    Writer.HTMLMarkup = Writer.HTMLMarkup.Replace("</html>", vbTab & HTMLObject.ToString & vbLf & "</html>")
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLParagraph) As HTMLWriter
    If IsNothing(Writer.HTMLMarkup) Then
      'Set first html tag
      Writer.HTMLMarkup = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
    End If
    Writer.HTMLMarkup = Writer.HTMLMarkup.Replace("</html>", vbTab & HTMLObject.ToString & vbLf & "</html>")
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLAnchor) As HTMLWriter
    If IsNothing(Writer.HTMLMarkup) Then
      'Set first html tag
      Writer.HTMLMarkup = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
    End If
    Writer.HTMLMarkup = Writer.HTMLMarkup.Replace("</html>", vbTab & HTMLObject.ToString & vbLf & "</html>")
    Return Writer
  End Operator

  Public Overloads Sub AddToHTMLMarkup(ByVal RawHTML As String)
    If IsNothing(str_html) Then
      'Set first html tag
      str_html = New StringBuilder
      str_html.Append("<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>")
    End If
    str_html = str_html.Replace("</html>", vbTab & RawHTML & vbLf & "</html>")
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLForm)
    If IsNothing(str_html) Then
      'Set first html tag
      str_html.Append("<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>")
    End If
    str_html = str_html.Replace("</html>", vbTab & Item.Markup & vbLf & "</html>")
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLHeader)
    If IsNothing(str_html) Then
      'Set first html tag
      str_html.Append("<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>")
    End If
    str_html = str_html.Replace("</html>", vbTab & Item.Markup & vbLf & "</html>")
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLTable)
    If IsNothing(str_html) Then
      'Set first html tag
      str_html.Append("<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>")
    End If
    str_html = str_html.Replace("</html>", vbTab & Item.Markup & vbLf & "</html>")
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLImageMap)
    If IsNothing(str_html) Then
      'Set first html tag
      str_html.Append("<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>")
    End If
    str_html = str_html.Replace("</html>", vbTab & Item.Markup & vbLf & "</html>")
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLList)
    If IsNothing(str_html) Then
      'Set first html tag
      str_html.Append("<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>")
    End If
    str_html = str_html.Replace("</html>", vbTab & Item.Markup & vbLf & "</html>")
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLImage)
    If IsNothing(str_html) Then
      'Set first html tag
      str_html.Append("<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>")
    End If
    str_html = str_html.Replace("</html>", vbTab & Item.Markup & vbLf & "</html>")
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLCanvas)
    If IsNothing(str_html) Then
      'Set first html tag
      str_html.Append("<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>")
    End If
    str_html = str_html.Replace("</html>", vbTab & Item.Markup & vbLf & "</html>")
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLParagraph)
    If IsNothing(str_html) Then
      'Set first html tag
      str_html.Append("<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>")
    End If
    str_html = str_html.Replace("</html>", vbTab & Item.Markup & vbLf & "</html>")
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLAnchor)
    If IsNothing(str_html) Then
      'Set first html tag
      str_html.Append("<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>")
    End If
    str_html = str_html.Replace("</html>", vbTab & Item.Markup & vbLf & "</html>")
  End Sub
  Public Sub AddBootstrapReference()
    If IsNothing(str_html) Then
      'Set first html tag
      str_html.Append("<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>")
    End If
    str_html = str_html.Replace("</html>", "<script src='https://ajax.googleapis.com/ajax/libs/jquery/2.2.0/jquery.min.js'></script></html>")
    str_html = str_html.Replace("</html>", "<link href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css' rel='stylesheet' integrity='sha256-7s5uDGW3AHqw6xtJmNNtr+OBRJUlgkNJEo78P4b0yRw= sha512-nNo+yCHEyn0smMxSswnf/OnX6/KwJuZTlNZBjauKhTK0c+zT+q5JOCx0UFhXQ6rJR9jg6Es8gPuD2uZcYDLqSw==' crossorigin='anonymous'/></html>")
    str_html = str_html.Replace("</html>", "<script type='text/javascript' src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js' integrity='sha256-KXn5puMvxCw+dAYznun+drMdG1IFl3agK0p/pqT9KAo= sha512-2e8qq0ETcfWRI4HJBzQiA3UoyFk6tbNyG+qSaIBZLyW9Xf3sWZHN/lxe9fTh1U45DpPf07yj94KsUHHWe4Yk1A==' crossorigin='anonymous'></script></html>")
  End Sub

  ''' <summary>
  ''' Represents an instance of a series of TextBox controls bound within the FieldSet HTML Element.
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLForm
    Private _form As String
    Private _attr As AttributeList
    ''' <summary>
    ''' Get/Set the HTML Markup for the current instance of an HTML Form.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Markup As String
      Get
        Return _form
      End Get
      Set(value As String)
        _form = value
      End Set
    End Property
    ''' <summary>
    ''' Creates a new instance of the HTML Form object.
    ''' </summary>
    ''' <param name="TEXT">The FieldSet Legend. Otherwise recognized as the label for the form.</param>
    ''' <remarks></remarks>
    Public Sub New(Optional ByVal Text As String = "", Optional ByVal Attributes As AttributeList = Nothing)
      If Not IsNothing(Attributes) Then
        _form = "<fieldset" & Attributes.ToString & "><legend>" & ReplaceBadChars(Text) & "</legend></fieldset>" & vbLf
      Else
        _form = "<fieldset><legend>" & ReplaceBadChars(Text) & "</legend></fieldset>" & vbLf
      End If
    End Sub

    ''' <summary>
    ''' Adds a new TextBox element to the current instance of an HTML Form.
    ''' </summary>
    ''' <param name="Label">Label text value</param>
    ''' <param name="Value">TextBox text value</param>
    ''' <param name="LabelAttributes">AttributeList for the Label</param>
    ''' <param name="TextAttributes">AttributeList for the TextBox</param>
    ''' <remarks></remarks>
    Public Sub CreateFormText(ByVal Label As String, ByVal Value As String, Optional ByVal LabelAttributes As AttributeList = Nothing, Optional ByVal TextAttributes As AttributeList = Nothing)
      If Not IsNothing(LabelAttributes) Then
        If Not IsNothing(TextAttributes) Then
          _form = _form.Replace("</fieldset>" & vbLf, "<span" & LabelAttributes.ToString & ">" & ReplaceBadChars(Label) & "</span><input" & TextAttributes.tostring & " disabled='disabled' value=" & Chr(34) & ReplaceBadChars(Value) & Chr(34) & "/><br/>" & vbLf & "</fieldset>" & vbLf)
        Else
          _form = _form.Replace("</fieldset>" & vbLf, "<span" & LabelAttributes.ToString & ">" & ReplaceBadChars(Label) & "</span><input disabled='disabled' value=" & Chr(34) & ReplaceBadChars(Value) & Chr(34) & "/><br/>" & vbLf & "</fieldset>" & vbLf)
        End If
      Else
        If Not IsNothing(TextAttributes) Then
          _form = _form.Replace("</fieldset>" & vbLf, "<span>" & ReplaceBadChars(Label) & "</span><input" & TextAttributes.ToString & " disabled='disabled' value=" & Chr(34) & ReplaceBadChars(Value) & Chr(34) & "/><br/>" & vbLf & "</fieldset>" & vbLf)
        Else
          _form = _form.Replace("</fieldset>" & vbLf, "<span>" & ReplaceBadChars(Label) & "</span><input disabled='disabled' value=" & chr(34) & ReplaceBadChars(Value) & chr(34) & "/><br/>" & vbLf & "</fieldset>" & vbLf)
        End If
      End If
    End Sub
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Header element.
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLHeader
    Private _header As New StringBuilder
    Private _attr As AttributeList
    Private _hs As HeaderSize
    Public Property Markup As String
      Get
        Return _header.ToString
      End Get
      Set(value As String)
        _header = New StringBuilder
        _header.Append(value)
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public Property Size As HeaderSize
      Get
        Return _hs
      End Get
      Set(value As HeaderSize)
        _hs = value
      End Set
    End Property
    Public Enum HeaderSize
      H1
      H2
      H3
      H4
      H5
      H6
    End Enum
    Public Overrides Function ToString() As String
      Return _header.ToString
    End Function

    ''' <summary>
    ''' Creates a new instance of the HTML Header object. 
    ''' This object serves as a Heading or Label in the layout of the HTML Document.
    ''' </summary>
    ''' <param name="TEXT"></param>
    ''' <param name="Attributes"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal InnerText As String, Optional ByVal Size As HeaderSize = HeaderSize.H1, Optional ByVal Attributes As AttributeList = Nothing)
      _hs = Size
      _attr = Attributes
      SetHeader(InnerText)
    End Sub

    Public Sub SetHeader(ByVal InnerText As String)
      _header = New StringBuilder
      _header.Append("<" & GetHeaderSizeString(_hs))
      If Not IsNothing(_attr) Then _header.Append(_attr.ToString)
      _header.Append(">" & ReplaceBadChars(InnerText) & "</" & GetHeaderSizeString(_hs) & ">")
    End Sub
    Public Function GetHeaderSizeString(ByVal Header As HeaderSize) As String
      Return Header.ToString
    End Function
  End Class

  ''' <summary>
  ''' Represent an instance of an HTML Paragraph element.
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLParagraph
    Private _p As New StringBuilder
    Private _attr As AttributeList

    Public Property Markup As String
      Get
        Return _p.ToString
      End Get
      Set(value As String)
        _p = New StringBuilder
        _p.Append(value)
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _p.ToString
    End Function

    Public Sub New(ByVal InnerText As String, Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      SetParagraph(InnerText)
    End Sub

    Public Sub SetParagraph(ByVal InnerText As String)
      _p = New StringBuilder
      _p.Append("<p")
      If Not IsNothing(_attr) Then _p.Append(_attr.tostring)
      _p.Append(">" & ReplaceBadChars(InnerText) & "</p>")
    End Sub

    Public Sub Append(ByVal ExtraText As String)
      If String.IsNullOrEmpty(_p.ToString) Then
        SetParagraph(ExtraText)
      Else
        _p.Insert(_p.ToString.LastIndexOf("<"), ReplaceBadChars(ExtraText))
      End If
    End Sub
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Table element.
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLTable
    Private _table As New StringBuilder
    Private _attr As AttributeList
    Private _rws() As HTMLTableRow

    ''' <summary>
    ''' Get/Set the HTML markup for the current instance of an HTML Table directly.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Markup As String
      Get
        Return _table.ToString
      End Get
      Set(value As String)
        _table = New StringBuilder
        _table.Append(value)
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public ReadOnly Property Count As Integer
      Get
        If Not IsNothing(_rws) Then
          Return _rws.Length
        Else
          Return -1
        End If
      End Get
    End Property
    Public Overrides Function ToString() As String
      Return _table.ToString
    End Function
    Public Overloads Shared Operator +(ByVal Table As HTMLTable, ByVal Row As HTMLTableRow) As HTMLTable
      Table.AddTableRow(Row)
      Return Table
    End Operator

    ''' <summary>
    ''' Creates a new instance of an HTML Table. A table consists of HTML Table Rows and their columns.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      SetTable()
      'If Not IsNothing(Attributes) Then
      '  _table.Append("<table" & Attributes.tostring & ">" & vbLf & "</table>" & vbLf)
      'Else
      '  _table.Append("<table>" & vbLf & "</table>" & vbLf)
      'End If
    End Sub
    Public Sub SetTable()
      _table = New StringBuilder
      Dim thead, tbody As StringBuilder
      thead = New StringBuilder
      tbody = New StringBuilder
      thead.AppendLine("<thead>")
      tbody.AppendLine("<tbody>")

      _table.Append("<table")
      If Not IsNothing(_attr) Then _table.Append(_attr.tostring)
      _table.Append(">" & vbLf)
      If Not IsNothing(_rws) Then
        For Each rw As HTMLTableRow In _rws
          If rw.CellType = HTMLTableCell.CellType.Header Then
            thead.AppendLine(rw.ToString)
          Else
            tbody.AppendLine(rw.ToString)
          End If
          '_table.AppendLine(rw.ToString)
        Next
      End If
      thead.AppendLine("</thead>")
      tbody.AppendLine("</tbody>")
      _table.AppendLine(thead.ToString)
      _table.AppendLine(tbody.ToString)
      _table.AppendLine("</table>")
    End Sub

    Public Sub AddTableRow(ByVal Row As HTMLTableRow)
      If Not IsNothing(_rws) Then
        ReDim Preserve _rws(_rws.Length)
      Else
        ReDim _rws(0)
      End If
      _rws(_rws.Length - 1) = Row
      SetTable()
    End Sub

    ''' <summary>
    ''' Represents the instance of an HTML Table Row.
    ''' </summary>
    ''' <remarks></remarks>
    Class HTMLTableRow
      Private _tr As New StringBuilder
      Private _attr As AttributeList
      Private _clType As HTMLTableCell.CellType
      Private _cls() As HTMLTableCell
      ''' <summary>
      ''' Get/Set the HTML markup for the current instance of an HTML Table Row directly.
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public ReadOnly Property Cells As HTMLTableCell()
        Get
          Return _cls
        End Get
      End Property
      Public ReadOnly Property CellType As HTMLTableCell.CellType
        Get
          Return _clType
        End Get
      End Property
      Public Property Markup As String
        Get
          Return _tr.ToString
        End Get
        Set(value As String)
          _tr = New StringBuilder
          _tr.Append(value)
        End Set
      End Property
      Public Property AttributeList As AttributeList
        Get
          Return _attr
        End Get
        Set(value As AttributeList)
          _attr = value
        End Set
      End Property
      Public ReadOnly Property Count As Integer
        Get
          If Not IsNothing(_cls) Then
            Return _cls.Length
          Else
            Return -1
          End If
        End Get
      End Property
      Public Overrides Function ToString() As String
        Return _tr.ToString
      End Function
      Public Overloads Shared Operator +(ByVal Row As HTMLTableRow, ByVal Cell As HTMLTableCell) As HTMLTableRow
        Row.AddTableCell(Cell)
        Return Row
      End Operator

      ''' <summary>
      ''' Creates a new instance of an HTML Table Row. A table row helps provide substance to the content of the table.
      ''' </summary>
      ''' <remarks></remarks>
      Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
        _attr = Attributes
        SetTableRow()
      End Sub

      Public Sub SetTableRow()
        _tr = New StringBuilder
        _tr.Append("<tr")
        If Not IsNothing(_attr) Then _tr.Append(_attr.ToString)
        _tr.Append(">" & vbLf)
        If Not IsNothing(_cls) Then
          For Each cl As HTMLTableCell In _cls
            _tr.AppendLine(cl.ToString)
          Next
        End If
        _tr.AppendLine("</tr>")
      End Sub
      ''' <summary>
      ''' Adds a column to the current instance of an HTML Table Row.
      ''' </summary>
      ''' <param name="InnerText">Inner text of the new table cell.</param>
      ''' <remarks></remarks>
      Public Overloads Sub AddTableColumn(ByVal InnerHTML As String, Optional ByVal Attributes As AttributeList = Nothing)
        AddTableCell(New HTMLTableCell(InnerHTML, HTMLTableCell.CellType.Row, Attributes))
        SetTableRow()
        'If Not IsNothing(Attributes) Then
        '  _tr = _tr.Replace("</tr>" & vbLf, vbTab & "<td" & Attributes.tostring & ">" & ReplaceBadChars(InnerHTML) & "</td>" & vbLf & "</tr>" & vbLf)
        'Else
        '  _tr = _tr.Replace("</tr>" & vbLf, vbTab & "<td>" & ReplaceBadChars(InnerHTML) & "</td>" & vbLf & "</tr>" & vbLf)
        'End If
      End Sub
      Public Overloads Sub AddTableCell(ByVal Cell As HTMLTable.HTMLTableCell)
        If Not IsNothing(_cls) Then
          ReDim Preserve _cls(_cls.Length)
        Else
          ReDim _cls(0)
        End If
        _cls(_cls.Length - 1) = Cell
        _clType = Cell.Type
        SetTableRow()
      End Sub


    End Class
    ''' <summary>
    ''' Represents the instance of an HTML Table Cell
    ''' </summary>
    ''' <remarks></remarks>
    Class HTMLTableCell
      Private _td As New StringBuilder
      Private _attr As AttributeList
      Private _ct As CellType
      Public Enum CellType
        Header
        Row
      End Enum
      Public ReadOnly Property Type As CellType
        Get
          Return _ct
        End Get
      End Property
      Public Property Markup As String
        Get
          Return _td.ToString
        End Get
        Set(value As String)
          _td = New StringBuilder
          _td.Append(value)
        End Set
      End Property
      Public Property AttributeList As AttributeList
        Get
          Return _attr
        End Get
        Set(value As AttributeList)
          _attr = value
        End Set
      End Property
      Public Overrides Function ToString() As String
        Return _td.ToString
      End Function

      Public Sub New(ByVal InnerHTML As String, ByVal CellType As CellType, Optional ByVal Attributes As AttributeList = Nothing)
        _attr = Attributes
        _ct = CellType
        SetTableCell(InnerHTML)
      End Sub

      Public Function SetTableCell(ByVal InnerHTML As String) As String
        _td = New StringBuilder
        Dim ct As String
        Select Case _ct
          Case CellType.Header
            ct = "th"
          Case CellType.Row
            ct = "td"
          Case Else
            Throw New ArgumentException("HTML Table Cell must have a Cell Type provided...")
        End Select
        If Not IsNothing(_attr) Then
          _td.Append("<" & ct & _attr.ToString)
        Else
          _td.Append("<" & ct)
        End If
        _td.Append(">" & ReplaceBadChars(InnerHTML) & "</" & ct & ">")
        Return _td.ToString
      End Function
    End Class
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Image with an HTML Image Map
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLImageMap
    Private _img As New StringBuilder
    Private _width As Integer
    Private _height As Integer
    Private _map As StringBuilder
    Private _imgmap As StringBuilder
    Private _attr As AttributeList
    ''' <summary>
    ''' Represents the type of shape each map area takes shape to.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ShapeType
      Poly
      Circle
      Rect
    End Enum

    ''' <summary>
    ''' Get the raw HTML markup that the current instance of an HTML Image Map represents.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Markup As String
      Get
        Return _imgmap.ToString
      End Get
    End Property
    ''' <summary>
    ''' Get the raw HTML markup that the current instance of an HTML Image Map has of a map.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Map As String
      Get
        Return _map.ToString
      End Get
    End Property
    ''' <summary>
    ''' Get/Set the location of the image. HTTP, File, etc.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageURL As String
      Get
        Return _img.ToString
      End Get
      Set(value As String)
        _img = New StringBuilder
        _img.Append(value)
      End Set
    End Property
    ''' <summary>
    ''' Get/Set the width of the HTML Image element.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageWidth As Integer
      Get
        Return _width
      End Get
      Set(value As Integer)
        _width = value
      End Set
    End Property
    ''' <summary>
    ''' Get/Set the height of the HTML Image element.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageHeight As Integer
      Get
        Return _height
      End Get
      Set(value As Integer)
        _height = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _imgmap.ToString & vbLf & _map.ToString
    End Function

    ''' <summary>
    ''' Creates a new instance of an HTML Image Map.
    ''' </summary>
    ''' <param name="Width">Width of the HTML Image element.</param>
    ''' <param name="Height">Height of the HTML Image element.</param>
    ''' <param name="ImageUrl">Location of the image. HTTP, File, etc.</param>
    ''' <param name="Map"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Width As Integer, ByVal Height As Integer, ByVal ImageUrl As String, ByVal Map As String, Optional ByVal Attributes As AttributeList = Nothing)
      _width = Width
      _height = Height
      _img = New StringBuilder : _img.Append(ImageUrl)
      _map = New StringBuilder : _map.Append(Map)
      _attr = Attributes
      If IsNothing(_width) = True Or IsNothing(_height) = True Or IsNothing(_img) = True Or IsNothing(_map) = True Then
        Throw New ApplicationException("{HTML}CreateImageMap: HTMLImageMap must of have all properties set. {ImageUrl,ImageWidth,ImageHeight,Map}")
      Else
        SetImageMap()
      End If
    End Sub
    Public Sub SetImageMap()
      If IsNothing(_width) = True Or IsNothing(_height) = True Or IsNothing(_img) = True Or IsNothing(_map) = True Then
        Throw New ApplicationException("{HTML}CreateImageMap: HTMLImageMap must of have all properties set. {ImageUrl,ImageWidth,ImageHeight,Map}")
      Else
        _imgmap.Append("<img")
        If Not IsNothing(_attr) Then _imgmap.Append(_attr.ToString)
        _imgmap.Append(" width=" & Chr(34) & _width.ToString & Chr(34) & " height=" & Chr(34) & _height.ToString & Chr(34) & " src=" & Chr(34) & _img.ToString & Chr(34) & " usemap=" & Chr(34) & _map.ToString & Chr(34) & "/>" & vbLf)
      End If
    End Sub

    ''' <summary>
    ''' Represents an instance of an HTML Map Area. This sets the bounds of the specified hyperlink onto its associated HTML Image
    ''' element.
    ''' </summary>
    ''' <remarks></remarks>
    Class HTMLMapArea
      Private _shape As String
      Private _coords As String
      Private _clickevent As String
      Private _href As String
      Private _target As String
      Private _frame As String
      Private _AREA As String

      ''' <summary>
      ''' Get the raw HTML markup for the current instance of an HTML Map Area.
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      ReadOnly Property MapArea As String
        Get
          Return _AREA
        End Get
      End Property
      ''' <summary>
      ''' Get/Set the target link.
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Property HREF As String
        Get
          Return _href
        End Get
        Set(value As String)
          _href = value
        End Set
      End Property
      ''' <summary>
      ''' Get/Set the name of a Client-Side function to be run as the OnClick event. JavaScript, VBScript, etc.
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Property OnClickEventName As String
        Get
          Return _clickevent
        End Get
        Set(value As String)
          _clickevent = value
        End Set
      End Property
      ''' <summary>
      ''' Set the target link type.
      ''' </summary>
      ''' <value>Blank: Opens a new window or tab.
      ''' Self: Redirects the current window.
      ''' Parent: Opens in the parent frame.
      ''' Top: Opens in the full body of the current window.
      ''' Frame: Opens in the specified iFrame HTML element. The iFrame ID property must be set.</value>
      ''' <remarks></remarks>
      WriteOnly Property Target As TargetType
        Set(value As TargetType)
          Select Case value
            Case TargetType.Blank
              _target = "_blank"
            Case TargetType.Self
              _target = "_self"
            Case TargetType.Parent
              _target = "_parent"
            Case TargetType.Top
              _target = "_top"
            Case TargetType.Frame
              If String.IsNullOrEmpty(_frame) = True Then
                Throw New ApplicationException("{HTML}Property - Target: HTMLMapArea TargetFrame must be set before applying to Target.")
              Else
                _target = _frame
              End If
          End Select
        End Set
      End Property
      ''' <summary>
      ''' Get/Set the iFrame ID to be used in the TargetType of Frame.
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Property TargetFrame As String
        Get
          Return _frame
        End Get
        Set(value As String)
          _frame = value
        End Set
      End Property
      ''' <summary>
      ''' Set the Shape Type of the current instance of an HTML Map Area.
      ''' </summary>
      ''' <value></value>
      ''' <remarks></remarks>
      WriteOnly Property Shape As ShapeType
        Set(value As ShapeType)
          Select Case value
            Case ShapeType.Rect
              _shape = "rect"
            Case ShapeType.Circle
              _shape = "circle"
            Case ShapeType.Poly
              _shape = "poly"
            Case Else
              Throw New ApplicationException("{HTML}Property - Shape: HTMLMapArea ShapeType not valid. Must be value {ShapeType.Rect,ShapeType.Cicle,or ShapeType.Poly}.")
          End Select
        End Set
      End Property
      ''' <summary>
      ''' Get the coordinates that represent the current instance of an HTML Map Area.
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      ReadOnly Property Coordinates As String
        Get
          Return _coords
        End Get
      End Property

      Public Overloads Sub CreateMapArea()
        _AREA = "<area "
        If Not String.IsNullOrEmpty(_shape) Then
          _AREA += "shape=" & Chr(34) & _shape & Chr(34) & " "
        Else
          Throw New ApplicationException("{HTML}CreateMapArea: HTMLMapArea ShapeType must be set before attempting to CreateMapArea().")
        End If
        If Not String.IsNullOrEmpty(_coords) Then
          _AREA += "coords=" & Chr(34) & _coords & Chr(34) & " "
        Else
          Throw New ApplicationException("{HTML}CreateMapArea: HTMLMapArea Coordinates must be set before attempting to CreateMapArea().")
        End If
        If Not String.IsNullOrEmpty(_target) Then
          _AREA += "target=" & Chr(34) & _target & Chr(34) & " "
        End If
        If Not String.IsNullOrEmpty(_href) Then
          _AREA += "href=" & Chr(34) & _href & Chr(34) & " "
        End If
        If Not String.IsNullOrEmpty(_clickevent) Then
          _AREA += "onClick=" & Chr(34) & _clickevent & Chr(34) & " "
        End If
        _AREA += ">"
      End Sub
      Public Overloads Sub CreateMapArea(ByVal Shape As ShapeType, ByVal Coordinates As String, ByVal OnClickEvent As String)
        Select Case Shape
          Case ShapeType.Rect
            _shape = "rect"
          Case ShapeType.Circle
            _shape = "circle"
          Case ShapeType.Poly
            _shape = "poly"
          Case Else
            Throw New ApplicationException("{HTML}CreateMapArea: HTMLMapArea ShapeType not valid. Must be value {ShapeType.Rect,ShapeType.Cicle,or ShapeType.Poly}.")
        End Select
        _coords = Coordinates
        _clickevent = OnClickEvent
        CreateMapArea()
      End Sub
      Public Overloads Sub CreateMapArea(ByVal Shape As ShapeType, ByVal Coordinates As String, Optional ByVal Target As TargetType = Nothing, Optional ByVal HREF As String = Nothing)
        Select Case Shape
          Case ShapeType.Rect
            _shape = "rect"
          Case ShapeType.Circle
            _shape = "circle"
          Case ShapeType.Poly
            _shape = "poly"
          Case Else
            Throw New ApplicationException("{HTML}CreateMapArea: HTMLMapArea ShapeType not valid. Must be value {ShapeType.Rect,ShapeType.Cicle,or ShapeType.Poly}.")
        End Select
        _coords = Coordinates
        Select Case Target
          Case TargetType.Blank
            _target = "_blank"
          Case TargetType.Self
            _target = "_self"
          Case TargetType.Parent
            _target = "_parent"
          Case TargetType.Top
            _target = "_top"
          Case TargetType.Frame
            If String.IsNullOrEmpty(_frame) Then
              Throw New ApplicationException("{HTML}CreateMapArea: HTMLMapArea TargetFrame must be set before applying to Target.")
            Else
              _target = _frame
            End If
        End Select
        _href = HREF
        CreateMapArea()
      End Sub

      Public Overloads Sub CreateRectangleCoordinates(ByVal X1 As String, ByVal Y1 As String, ByVal X2 As String, ByVal Y2 As String)
        If Not _shape = "rect" Then
          Throw New ApplicationException("{HTML}CreateRectangleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = X1.ToString & "," & Y1.ToString & "," & X2.ToString & "," & Y2.ToString
        End If
      End Sub
      Public Overloads Sub CreateRectangleCoordinates(ByVal X1 As Integer, ByVal Y1 As Integer, ByVal X2 As Integer, ByVal Y2 As Integer)
        If Not _shape = "rect" Then
          Throw New ApplicationException("{HTML}CreateRectangleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = X1.ToString & "," & Y1.ToString & "," & X2.ToString & "," & Y2.ToString
        End If
      End Sub
      Public Overloads Sub CreateRectangleCoordinates(ByVal X1 As Double, ByVal Y1 As Double, ByVal X2 As Double, ByVal Y2 As Double)
        If Not _shape = "rect" Then
          Throw New ApplicationException("{HTML}CreateRectangleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = X1.ToString & "," & Y1.ToString & "," & X2.ToString & "," & Y2.ToString
        End If
      End Sub
      Public Overloads Sub CreateRectangleCoordinates(ByVal X1 As Decimal, ByVal Y1 As Decimal, ByVal X2 As Decimal, ByVal Y2 As Decimal)
        If Not _shape = "rect" Then
          Throw New ApplicationException("{HTML}CreateRectangleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = X1.ToString & "," & Y1.ToString & "," & X2.ToString & "," & Y2.ToString
        End If
      End Sub
      Public Overloads Sub CreateRectangleCoordinates(ByVal P1 As Point, ByVal P2 As Point)
        If Not _shape = "rect" Then
          Throw New ApplicationException("{HTML}CreateRectangleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = P1.X.ToString & "," & P1.Y.ToString & "," & P2.X.ToString & "," & P2.Y.ToString
        End If
      End Sub
      Public Overloads Sub CreateRectangleCoordinates(ByVal R As Rectangle)
        If Not _shape = "rect" Then
          Throw New ApplicationException("{HTML}CreateRectangleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = R.X.ToString & "," & R.Y.ToString & "," & (R.Width + R.X).ToString & "," & (R.Height + R.Y).ToString
        End If
      End Sub

      Public Overloads Sub CreateCircleCoordinates(ByVal X As String, ByVal Y As String, ByVal Radius As String)
        If Not _shape = "circle" Then
          Throw New ApplicationException("{HTML}CreateCircleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = X.ToString & "," & Y.ToString & "," & Radius.ToString
        End If
      End Sub
      Public Overloads Sub CreateCircleCoordinates(ByVal X As Integer, ByVal Y As Integer, ByVal Radius As Integer)
        If Not _shape = "circle" Then
          Throw New ApplicationException("{HTML}CreateCircleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = X.ToString & "," & Y.ToString & "," & Radius.ToString
        End If
      End Sub
      Public Overloads Sub CreateCircleCoordinates(ByVal X As Double, ByVal Y As Double, ByVal Radius As Double)
        If Not _shape = "circle" Then
          Throw New ApplicationException("{HTML}CreateCircleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = X.ToString & "," & Y.ToString & "," & Radius.ToString
        End If
      End Sub
      Public Overloads Sub CreateCircleCoordinates(ByVal X As Decimal, ByVal Y As Decimal, ByVal Radius As Decimal)
        If Not _shape = "circle" Then
          Throw New ApplicationException("{HTML}CreateCircleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = X.ToString & "," & Y.ToString & "," & Radius.ToString
        End If
      End Sub
      Public Overloads Sub CreateCircleCoordinates(ByVal Center As Point, ByVal Radius As Decimal)
        If Not _shape = "circle" Then
          Throw New ApplicationException("{HTML}CreateCircleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = Center.X.ToString & "," & Center.Y.ToString & "," & Radius.ToString
        End If
      End Sub
      Public Overloads Sub CreateCircleCoordinates(ByVal Center As Point, ByVal Radius As Double)
        If Not _shape = "circle" Then
          Throw New ApplicationException("{HTML}CreateCircleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = Center.X.ToString & "," & Center.Y.ToString & "," & Radius.ToString
        End If
      End Sub
      Public Overloads Sub CreateCircleCoordinates(ByVal Center As Point, ByVal Radius As Integer)
        If Not _shape = "circle" Then
          Throw New ApplicationException("{HTML}CreateCircleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = Center.X.ToString & "," & Center.Y.ToString & "," & Radius.ToString
        End If
      End Sub
      Public Overloads Sub CreateCircleCoordinates(ByVal Center As Point, ByVal Radius As String)
        If Not _shape = "circle" Then
          Throw New ApplicationException("{HTML}CreateCircleCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          _coords = Center.X.ToString & "," & Center.Y.ToString & "," & Radius.ToString
        End If
      End Sub

      Public Overloads Sub AddPolyCoordinate(ByVal XCoordinate As Double, ByVal YCoordinate As Double)
        If Not _shape = "poly" Then
          Throw New ApplicationException("{HTML}AddPolyCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          If String.IsNullOrEmpty(_coords) Then
            'Add first coordinate
            _coords = XCoordinate.ToString & "," & YCoordinate.ToString
          Else
            'Add subsequent coordinate
            _coords += "," & XCoordinate.ToString & "," & YCoordinate.ToString
          End If
        End If
      End Sub
      Public Overloads Sub AddPolyCoordinate(ByVal XCoordinate As String, ByVal YCoordinate As String)
        If Not _shape = "poly" Then
          Throw New ApplicationException("{HTML}AddPolyCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          If IsNumeric(XCoordinate) = False Or IsNumeric(YCoordinate) = False Then
            Throw New ApplicationException("{HTML}AddPolyCoordinates: HTMLMapArea coordinates must be of numeric value.")
          End If
          If String.IsNullOrEmpty(_coords) Then
            'Add first coordinate
            _coords = XCoordinate.ToString & "," & YCoordinate.ToString
          Else
            'Add subsequent coordinate
            _coords += "," & XCoordinate.ToString & "," & YCoordinate.ToString
          End If
        End If
      End Sub
      Public Overloads Sub AddPolyCoordinate(ByVal XCoordinate As Integer, ByVal YCoordinate As Integer)
        If Not _shape = "poly" Then
          Throw New ApplicationException("{HTML}AddPolyCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          If String.IsNullOrEmpty(_coords) Then
            'Add first coordinate
            _coords = XCoordinate.ToString & "," & YCoordinate.ToString
          Else
            'Add subsequent coordinate
            _coords += "," & XCoordinate.ToString & "," & YCoordinate.ToString
          End If
        End If
      End Sub
      Public Overloads Sub AddPolyCoordinate(ByVal XCoordinate As Decimal, ByVal YCoordinate As Decimal)
        If Not _shape = "poly" Then
          Throw New ApplicationException("{HTML}AddPolyCoordinates: HTMLMapArea ShapeType has not been set. Must set ShapeType to ensure proper MapArea creation.")
        Else
          If String.IsNullOrEmpty(_coords) Then
            'Add first coordinate
            _coords = XCoordinate.ToString & "," & YCoordinate.ToString
          Else
            'Add subsequent coordinate
            _coords += "," & XCoordinate.ToString & "," & YCoordinate.ToString
          End If
        End If
      End Sub
    End Class

    ''' <summary>
    ''' Adds a new instance of an HTML Map Area to the Map element of the current instance of an HTML Image Map.
    ''' </summary>
    ''' <param name="Area">HTML Map Area object.</param>
    ''' <param name="MapName">Only applies to first addition of an HTML Map Area, this sets the name of the HTML Image Map.
    ''' This name is used when applying coordinates to an HTML Image element.</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddMapArea(ByVal Area As HTMLMapArea, Optional ByVal MapName As String = "map0")
      If IsNothing(_map) Then
        _map.Append("<map name=" & Chr(34) & MapName & Chr(34) & ">" & vbLf & vbTab & Area.MapArea & vbLf & "</map>" & vbLf)
      Else
        _map = _map.Replace("</map>" & vbLf, vbTab & Area.MapArea & vbLf & "</map>" & vbLf)
      End If
    End Sub
    ''' <summary>
    ''' Adds a new instance of an HTML Map Area to the Map element of the current instance of an HTML Image Map.
    ''' </summary>
    ''' <param name="Area">Raw HTML Markup for a Map Area.</param>
    ''' <param name="MapName">Only applies to the first addition of an HTML Map Area, this sets the name of the HTML Image Map.
    ''' This name is used when applying coordinates to an HTML Image element.</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddMapArea(ByVal Area As String, Optional ByVal MapName As String = "map0")
      If IsNothing(_map) Then
        _map.Append("<map name=" & Chr(34) & MapName & Chr(34) & ">" & vbLf & vbTab & Area & vbLf & "</map>" & vbLf)
      Else
        _map = _map.Replace("</map>" & vbLf, vbTab & Area & vbLf & "</map>" & vbLf)
      End If
    End Sub
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML List. Consists of either bulleted or numbered lists.
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLList
    Private _list As New StringBuilder
    Private _attr As AttributeList
    Private _ltype As ListType
    Private _lis() As ListItem

    ''' <summary>
    ''' Get the raw HTML markup for the current instance of an HTML List.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property Markup As String
      Get
        SetList()
        Return _list.ToString
      End Get
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    ''' <summary>
    ''' Represents the type of list.
    ''' Ordered: Numbered list. Automatically increments the "bullets"
    ''' Unordered: Simple bulleted list represented by images. CSS can change the images.
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum ListType
      Ordered
      Unordered
    End Enum
    ''' <summary>
    ''' Get/Set the type for the current instance of an HTML List.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ThisListType As ListType
      Get
        Return _ltype
      End Get
      Set(value As ListType)
        _ltype = value
      End Set
    End Property
    Public ReadOnly Property Count As Integer
      Get
        If Not IsNothing(_lis) Then
          Return _lis.Length
        Else
          Return -1
        End If
      End Get
    End Property
    Public Overrides Function ToString() As String
      SetList()
      Return _list.ToString
    End Function
    Public Overloads Shared Operator +(ByVal List As HTMLList, ByVal Item As ListItem) As HTMLList
      List.AddListItem(Item)
      Return List
    End Operator

    Private Function GetListTypeTag(ByVal Type As ListType) As String
      Select Case Type
        Case ListType.Ordered
          Return "ol"
        Case ListType.Unordered
          Return "ul"
        Case Else
          Throw New ApplicationException("{HTML}GetListTypeTag: 'Type' cannot be null, must have a ListType identified or the HTML will become improperly formatted.")
      End Select
    End Function

    Public Sub New(ByVal ListType As ListType, Optional ByVal Attributes As AttributeList = Nothing)
      _ltype = ListType
      _attr = Attributes
      SetList()
    End Sub

    Public Sub AddListItem(ByVal ListItem As ListItem)
      If Not IsNothing(_lis) Then
        ReDim Preserve _lis(_lis.Length)
      Else
        ReDim _lis(0)
      End If
      _lis(_lis.Length - 1) = ListItem

      SetList()
    End Sub
    Public Sub SetList()
      _list = New StringBuilder
      _list.Append("<" & GetListTypeTag(_ltype))
      If Not IsNothing(_attr) Then _list.Append(_attr.ToString)
      _list.Append(">" & vbLf)
      If Not IsNothing(_lis) Then
        For Each li As ListItem In _lis
          _list.AppendLine(li.ToString)
        Next
      End If
      _list.AppendLine("</" & GetListTypeTag(_ltype) & ">")
    End Sub

    Public Class ListItem
      Private _li As StringBuilder
      Private _attr As AttributeList
      Private _inner As StringBuilder

      Public Property Markup As String
        Get
          SetListItem(_inner.ToString)
          Return _li.ToString
        End Get
        Set(value As String)
          _li = New StringBuilder
          _li.Append(value)
        End Set
      End Property
      Public Property InnerHTML As String
        Get
          Return _inner.ToString
        End Get
        Set(value As String)
          _inner = New StringBuilder(value)
        End Set
      End Property
      Public Property AttributeList As AttributeList
        Get
          Return _attr
        End Get
        Set(value As AttributeList)
          _attr = value
        End Set
      End Property
      Public Overrides Function ToString() As String
        SetListItem(_inner.ToString)
        Return _li.ToString
      End Function

      Public Sub New(ByVal InnerHTML As String, Optional ByVal Attributes As AttributeList = Nothing)
        _attr = Attributes
        _inner = New StringBuilder(InnerHTML)
        SetListItem(InnerHTML)
      End Sub

      ''' <summary>
      ''' Resets the inner html of the current instance of a list item.
      ''' </summary>
      ''' <param name="InnerHTML">The html markup that will take up the inner html of the element</param>
      ''' <remarks></remarks>
      Public Sub SetListItem(Optional ByVal InnerHTML As String = "")
        If Not String.IsNullOrEmpty(InnerHTML) Then _inner = New StringBuilder(InnerHTML)
        _li = New StringBuilder
        _li.Append("<li")
        If Not IsNothing(_attr) Then _li.Append(_attr.ToString)
        _li.Append(">" & ReplaceBadChars(_inner.ToString) & "</li>")
      End Sub
      Public Sub AddInnerHTML(ByVal InnerHTML As String)
        If IsNothing(_li) Then
          SetListItem(InnerHTML)
        Else
          _inner.Append(InnerHTML)
          SetListItem(_inner.ToString)
        End If
      End Sub
    End Class
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Image.
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLImage
    Private _img As New StringBuilder
    Private _attr As AttributeList

    Public ReadOnly Property Markup As String
      Get
        Return _img.ToString
      End Get
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _img.ToString
    End Function

    ''' <summary>
    ''' Creates a new instance of the HTML Header object. 
    ''' This object serves as a Heading or Label in the layout of the HTML Document.
    ''' </summary>
    ''' <param name="Source"></param>
    ''' <param name="Attributes"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Source As String, Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      SetImage(Source)
    End Sub

    Public Sub SetImage(ByVal Source As String)
      _img = New StringBuilder
      _img.Append("<img")
      If Not IsNothing(_attr) Then _img.Append(_attr.ToString)
      _img.Append(" src=" & Chr(34) & ReplaceBadChars(Source) & Chr(34) & " />")
    End Sub
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Canvas
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLCanvas
    Private _cnv As New StringBuilder
    Private _id As String
    Private _attr As AttributeList

    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public ReadOnly Property Markup As String
      Get
        Return _cnv.ToString
      End Get
    End Property
    Public Overrides Function ToString() As String
      Return _cnv.ToString
    End Function

    Public Sub New(ByVal ID As String, Optional ByVal Attributes As AttributeList = Nothing)
      _id = ID
      _attr = Attributes
      SetCanvas()
    End Sub

    Public Sub SetCanvas()
      _cnv = New StringBuilder
      _cnv.Append("<canvas")
      If Not IsNothing(_attr) Then _cnv.Append(_attr.ToString)
      _cnv.Append(" id=" & Chr(34) & _id & Chr(34) & ">This browser does not appear to support the HTML Canvas tag...</canvas>")
    End Sub
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Anchor
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLAnchor
    Private _a As New StringBuilder
    Private _attr As AttributeList
    Private _name, _href, _targetFrame As String
    Private _target As TargetType

    ''' <summary>
    ''' Get/Set the HTML markup for the current instance of an HTML Anchor directly.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Markup As String
      Get
        Return _a.ToString
      End Get
      Set(value As String)
        _a = New StringBuilder
        _a.Append(value)
      End Set
    End Property
    Public Property Name As String
      Get
        Return _name
      End Get
      Set(value As String)
        _name = value
      End Set
    End Property
    Public Property HREF As String
      Get
        Return _href
      End Get
      Set(value As String)
        _href = value
      End Set
    End Property
    Public Property Target As TargetType
      Get
        Return _target
      End Get
      Set(value As TargetType)
        _target = value
      End Set
    End Property
    Public Property TargetFrameName As String
      Get
        Return _targetFrame
      End Get
      Set(value As String)
        _targetFrame = value
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _a.ToString
    End Function

    Public Sub New(ByVal InnerText As String, Optional ByVal Name As String = "a1", Optional ByVal HREF As String = "#", Optional ByVal Target As TargetType = TargetType.Self, Optional ByVal TargetFrame As String = "", Optional ByVal Attributes As AttributeList = Nothing)
      _name = Name
      _href = HREF
      _target = Target
      _targetFrame = TargetFrame
      _attr = Attributes
      SetAnchor(InnerText)
    End Sub

    Public Sub SetAnchor(ByVal InnerText As String)
      _a = New StringBuilder
      _a.Append("<a")
      If Not IsNothing(_attr) Then _a.Append(_attr.ToString & "")
      If Not String.IsNullOrEmpty(Name) And Not Name = "a1" Then
        _a.Append(" name=" & Chr(34) & Name & Chr(34))
      End If
      If Not String.IsNullOrEmpty(HREF) And Not HREF = "#" Then
        _a.Append(" href=" & Chr(34) & HREF & Chr(34))
      End If
      If Not String.IsNullOrEmpty(TargetFrameName) And Not TargetFrameName = "" Then
        Target = TargetType.Frame
        _a.Append(" target=" & Chr(34) & TargetFrameName & Chr(34))
      Else
        If Not IsNothing(Target) Then
          _a.Append(" target=" & Chr(34) & GetTargetTypeString(Target) & Chr(34))
        End If
      End If
      _a.Append(">" & ReplaceBadChars(InnerText) & "</a>" & vbLf)
    End Sub
    Private Function GetTargetTypeString(ByVal Target As TargetType) As String
      Select Case Target
        Case TargetType.Blank
          Return "_blank"
        Case TargetType.Parent
          Return "_parent"
        Case TargetType.Self
          Return "_self"
        Case TargetType.Top
          Return "_top"
        Case TargetType.Frame
          If Not String.IsNullOrEmpty(_targetFrame) Then
            Return _targetFrame
          Else
            Throw New ArgumentException("You must specify or handle a Named Frame for the TargetType of Frame! Unspecified Target Frame name.")
          End If
        Case Else
          Throw New ArgumentException("Target Type not specified!")
      End Select
    End Function
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Input
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLInput
    Private _input As New StringBuilder
    Private _attr As AttributeList
    Private _type As InputType

    Public Property Markup As String
      Get
        Return _input.ToString
      End Get
      Set(value As String)
        _input = New StringBuilder
        _input.Append(value)
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public Property Type As InputType
      Get
        Return _type
      End Get
      Set(value As InputType)
        _type = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _input.ToString
    End Function

    Public Sub New(ByVal Type As InputType, Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      _type = Type
      SetInput()
    End Sub

    Public Sub SetInput()
      _input = New StringBuilder
      _input.Append("<input type=" & Chr(34) & InputTypeString(_type) & Chr(34))
      If Not IsNothing(_attr) Then _input.Append(_attr.ToString)
      _input.Append(" />")
    End Sub

    Private Function InputTypeString(ByVal InputType As InputType) As String
      Select Case InputType
        Case HTMLWriter.InputType.iButton
          Return "button"
        Case HTMLWriter.InputType.iCheckBox
          Return "checkbox"
        Case HTMLWriter.InputType.iColor
          Return "color"
        Case HTMLWriter.InputType.iDate
          Return "date"
        Case HTMLWriter.InputType.iDateTime
          Return "datetime"
        Case HTMLWriter.InputType.iDateTimeLocal
          Return "datetime-local"
        Case HTMLWriter.InputType.iEmail
          Return "email"
        Case HTMLWriter.InputType.iMonth
          Return "month"
        Case HTMLWriter.InputType.iNumber
          Return "number"
        Case HTMLWriter.InputType.iPassword
          Return "password"
        Case HTMLWriter.InputType.iRadio
          Return "radio"
        Case HTMLWriter.InputType.iRange
          Return "range"
        Case HTMLWriter.InputType.iSearch
          Return "search"
        Case HTMLWriter.InputType.iSubmit
          Return "submit"
        Case HTMLWriter.InputType.iTel
          Return "tel"
        Case HTMLWriter.InputType.iText
          Return "text"
        Case HTMLWriter.InputType.iTime
          Return "time"
        Case HTMLWriter.InputType.iUrl
          Return "url"
        Case HTMLWriter.InputType.iWeek
          Return "week"
        Case Else
          Return ""
      End Select
    End Function
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Label
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLLabel
    Private _label As New StringBuilder
    Private _attr As AttributeList

    Public Property Markup As String
      Get
        Return _label.ToString
      End Get
      Set(value As String)
        _label = New StringBuilder
        _label.Append(value)
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _label.ToString
    End Function

    Public Sub New(ByVal InnerText As String, Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      SetLabel(InnerText)
    End Sub

    Public Sub SetLabel(ByVal InnerText As String)
      _label = New StringBuilder
      _label.Append("<label")
      If Not IsNothing(_attr) Then _label.Append(_attr.ToString)
      _label.Append(">" & ReplaceBadChars(InnerText) & "</label>")
    End Sub
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Select
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLSelect
    Private _select As New StringBuilder
    Private _attr As AttributeList
    Private _ops() As HTMLOption

    Public Property Markup As String
      Get
        Return _select.ToString
      End Get
      Set(value As String)
        _select = New StringBuilder
        _select.Append(value)
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public Property Options As HTMLOption()
      Get
        Return _ops
      End Get
      Set(value As HTMLOption())
        _ops = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _select.ToString
    End Function
    Public Overloads Shared Operator +(ByVal HTMLSelect As HTMLSelect, ByVal NewOption As HTMLOption) As HTMLSelect
      HTMLSelect.AddOption(NewOption)
      Return HTMLSelect
    End Operator

    Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      SetSelect()
    End Sub

    Public Sub SetSelect()
      _select = New StringBuilder
      _select.Append("<select")
      If Not IsNothing(_attr) Then _select.Append(_attr.ToString)
      _select.Append(">" & vbLf)
      If Not IsNothing(_ops) Then
        For Each op As HTMLOption In _ops
          _select.AppendLine(vbTab & op.ToString)
        Next
      End If
      _select.AppendLine("</select>")
    End Sub
    Public Sub AddOption(ByVal NewOption As HTMLOption)
      If Not IsNothing(_ops) Then
        ReDim Preserve _ops(_ops.Length)
      Else
        ReDim _ops(0)
      End If
      _ops(_ops.Length - 1) = NewOption
      SetSelect()
    End Sub

    Public Class HTMLOption
      Private _option As StringBuilder
      Private _attr As AttributeList
      Private _val As String

      Public Property Markup As String
        Get
          Return _option.ToString
        End Get
        Set(value As String)
          _option = New StringBuilder
          _option.Append(value)
        End Set
      End Property
      Public Property Value As String
        Get
          Return _val
        End Get
        Set(value As String)
          _val = value
          SetOption()
        End Set
      End Property
      Public Property AttributeList As AttributeList
        Get
          Return _attr
        End Get
        Set(value As AttributeList)
          _attr = value
        End Set
      End Property
      Public Overrides Function ToString() As String
        Return _option.ToString
      End Function

      Public Sub New(ByVal InnerText As String, Optional ByVal Attributes As AttributeList = Nothing)
        _attr = Attributes
        _val = InnerText
        SetOption()
      End Sub

      Public Sub SetOption()
        _option = New StringBuilder
        _option.Append("<option")
        If Not IsNothing(_attr) Then _option.Append(_attr.ToString)
        _option.Append(">" & ReplaceBadChars(_val) & "</option>")
      End Sub
    End Class
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Progress
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLProgress
    Private _progress As New StringBuilder
    Private _attr As AttributeList

    Public Property Markup As String
      Get
        Return _progress.ToString
      End Get
      Set(value As String)
        _progress = New StringBuilder
        _progress.Append(value)
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _progress.ToString
    End Function

    Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      SetProgress()
    End Sub

    Public Sub SetProgress()
      _progress = New StringBuilder
      _progress.Append("<progress")
      If Not IsNothing(_attr) Then _progress.Append(_attr.ToString)
      _progress.Append("></progress>")
    End Sub
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Meter
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLMeter
    Private _meter As New StringBuilder
    Private _attr As AttributeList

    Public Property Markup As String
      Get
        Return _meter.ToString
      End Get
      Set(value As String)
        _meter = New StringBuilder
        _meter.Append(value)
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _meter.ToString
    End Function

    Public Sub New(Optional ByVal InnerText As String = "", Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      SetMeter(InnerText)
    End Sub

    Public Sub SetMeter(Optional ByVal InnerText As String = "")
      _meter = New StringBuilder
      _meter.Append("<meter")
      If Not IsNothing(_attr) Then _meter.Append(_attr.ToString)
      _meter.Append(">" & ReplaceBadChars(InnerText) & "</meter>")
    End Sub
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Video
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLVideo
    Private _video As New StringBuilder
    Private _attr As AttributeList
    Private _srcs() As HTMLSource

    Public Property Markup As String
      Get
        Return _video.ToString
      End Get
      Set(value As String)
        _video = New StringBuilder
        _video.Append(value)
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public Property Sources As HTMLSource()
      Get
        Return _srcs
      End Get
      Set(value As HTMLSource())
        _srcs = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _video.ToString
    End Function
    Public Overloads Shared Operator +(ByVal Video As HTMLVideo, ByVal Source As HTMLSource) As HTMLVideo
      Video.AddSource(Source)
      Return Video
    End Operator

    Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      SetVideo()
    End Sub

    Public Sub SetVideo()
      _video = New StringBuilder
      _video.Append("<video")
      If Not IsNothing(_attr) Then _video.Append(_attr.ToString)
      _video.Append(">" & vbLf)
      If Not IsNothing(_srcs) Then
        For Each src As HTMLSource In _srcs
          _video.AppendLine(src.ToString)
        Next
      End If
      _video.AppendLine("</video>")
    End Sub
    Public Sub AddSource(ByVal Source As HTMLSource)
      If Not IsNothing(_srcs) Then
        ReDim Preserve _srcs(_srcs.Length)
      Else
        ReDim _srcs(0)
      End If
      _srcs(_srcs.Length - 1) = Source
      SetVideo()
    End Sub

    Class HTMLSource
      Private _source As New StringBuilder
      Private _attr As AttributeList

      Public Property Markup As String
        Get
          Return _source.ToString
        End Get
        Set(value As String)
          _source = New StringBuilder
          _source.Append(value)
        End Set
      End Property
      Public Property AttributeList As AttributeList
        Get
          Return _attr
        End Get
        Set(value As AttributeList)
          _attr = value
        End Set
      End Property
      Public Overrides Function ToString() As String
        Return _source.ToString
      End Function

      Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
        _attr = Attributes
        SetSource()
      End Sub

      Public Sub SetSource()
        _source = New StringBuilder
        _source.Append("<source")
        If Not IsNothing(_attr) Then _source.Append(_attr.ToString)
        _source.Append(">")
      End Sub
    End Class
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Audio
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLAudio
    Private _audio As New StringBuilder
    Private _attr As AttributeList
    Private _srcs() As HTMLSource

    Public Property Markup As String
      Get
        Return _audio.ToString
      End Get
      Set(value As String)
        _audio = New StringBuilder
        _audio.Append(value)
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public Property Sources As HTMLSource()
      Get
        Return _srcs
      End Get
      Set(value As HTMLSource())
        _srcs = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _audio.ToString
    End Function
    Public Overloads Shared Operator +(ByVal Audio As HTMLAudio, ByVal Source As HTMLSource) As HTMLAudio
      Audio.AddSource(Source)
      Return Audio
    End Operator

    Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      SetAudio()
    End Sub

    Public Sub SetAudio()
      _audio = New StringBuilder
      _audio.Append("<audio")
      If Not IsNothing(_attr) Then _audio.Append(_attr.ToString)
      _audio.Append(">" & vbLf)
      If Not IsNothing(_srcs) Then
        For Each src As HTMLSource In _srcs
          _audio.AppendLine(src.ToString)
        Next
      End If
      _audio.AppendLine("</audio>")
    End Sub
    Public Sub AddSource(ByVal Source As HTMLSource)
      If Not IsNothing(_srcs) Then
        ReDim Preserve _srcs(_srcs.Length)
      Else
        ReDim _srcs(0)
      End If
      _srcs(_srcs.Length - 1) = Source
      SetAudio()
    End Sub

    Class HTMLSource
      Private _source As New StringBuilder
      Private _attr As AttributeList

      Public Property Markup As String
        Get
          Return _source.ToString
        End Get
        Set(value As String)
          _source = New StringBuilder
          _source.Append(value)
        End Set
      End Property
      Public Property AttributeList As AttributeList
        Get
          Return _attr
        End Get
        Set(value As AttributeList)
          _attr = value
        End Set
      End Property
      Public Overrides Function ToString() As String
        Return _source.ToString
      End Function

      Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
        _attr = Attributes
        SetSource()
      End Sub

      Public Sub SetSource()
        _source = New StringBuilder
        _source.Append("<source")
        If Not IsNothing(_attr) Then _source.Append(_attr.ToString)
        _source.Append(">")
      End Sub
    End Class
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Div
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLDiv
    Private _div As New StringBuilder
    Private _attr As AttributeList
    Private _inner As StringBuilder
    Public Property Markup As String
      Get
        Return _div.ToString
      End Get
      Set(value As String)
        _div = New StringBuilder
        _div.Append(value)
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public Property InnerHTML As String
      Get
        Return _inner.ToString
      End Get
      Set(value As String)
        _inner = New StringBuilder
        _inner.Append(value)
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _div.ToString
    End Function
    Public Overloads Shared Operator +(ByVal Div As HTMLDiv, ByVal ExtraHTML As String) As HTMLDiv
      Div.AppendDiv(ExtraHTML)
      Return Div
    End Operator

    Public Sub New(Optional ByVal InnerHTML As String = "", Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      _inner = New StringBuilder
      _inner.Append(InnerHTML)
      SetDiv()
    End Sub

    Public Sub SetDiv(Optional ByVal InnerHTML As String = "")
      If Not String.IsNullOrEmpty(InnerHTML) Then _inner = New StringBuilder : _inner.Append(InnerHTML)
      _div = New StringBuilder
      _div.Append("<div")
      If Not IsNothing(_attr) Then _div.Append(_attr.ToString)
      _div.Append(">" & vbLf)
      _div.AppendLine(_inner.ToString)
      _div.AppendLine("</div>")
    End Sub
    Public Sub AppendDiv(ByVal ExtraHTML As String)
      _inner.Append(ExtraHTML)
      SetDiv()
    End Sub
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Span
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLSpan
    Private _span As New StringBuilder
    Private _attr As AttributeList
    Private _inner As StringBuilder
    Public Property Markup As String
      Get
        Return _span.ToString
      End Get
      Set(value As String)
        _span = New StringBuilder
        _span.Append(value)
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
      End Set
    End Property
    Public Property InnerHTML As String
      Get
        Return _inner.ToString
      End Get
      Set(value As String)
        _inner = New StringBuilder
        _inner.Append(value)
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _span.ToString
    End Function
    Public Overloads Shared Operator +(ByVal Span As HTMLSpan, ByVal ExtraHTML As String) As HTMLSpan
      Span.AppendSpan(ExtraHTML)
      Return Span
    End Operator

    Public Sub New(Optional ByVal InnerHTML As String = "", Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      _inner = New StringBuilder
      _inner.Append(InnerHTML)
      SetSpan()
    End Sub

    Public Sub SetSpan(Optional ByVal InnerHTML As String = "")
      If Not String.IsNullOrEmpty(InnerHTML) Then _inner = New StringBuilder : _inner.Append(InnerHTML)
      _span = New StringBuilder
      _span.Append("<div")
      If Not IsNothing(_attr) Then _span.Append(_attr.ToString)
      _span.Append(">" & vbLf)
      _span.AppendLine(_inner.ToString)
      _span.AppendLine("</div>")
    End Sub
    Public Sub AppendSpan(ByVal ExtraHTML As String)
      _inner.Append(ExtraHTML)
      SetSpan()
    End Sub
  End Class

End Class
Public Class AttributeList
  Private _attr As New StringBuilder
  Private _ai As List(Of AttributeItem)
  Private _si As List(Of StyleItem)
  Public Property Markup As String
    Get
      SetAttributeList()
      Return _attr.ToString
    End Get
    Set(value As String)
      _attr = New StringBuilder
      _attr.Append(value)
    End Set
  End Property
  Public Overrides Function ToString() As String
    SetAttributeList()
    Return _attr.ToString
  End Function
  Public Overloads Shared Operator +(ByVal Attributes As AttributeList, ByVal Attribute As AttributeItem) As AttributeList
    Attributes.AddAttribute(Attribute)
    Return Attributes
  End Operator
  Public Overloads Shared Operator +(ByVal Attributes As AttributeList, ByVal StyleAttribute As StyleItem) As AttributeList
    Attributes.AddStyleItem(StyleAttribute)
    Return Attributes
  End Operator

  Public Sub AddAttribute(ByVal Attribute As AttributeItem)
    'If Not IsNothing(_ai) Then
    '  ReDim Preserve _ai(_ai.Length)
    'Else
    '  ReDim _ai(0)
    'End If
    '_ai(_ai.Length - 1) = Attribute
    If IsNothing(_ai) Then _ai = New List(Of AttributeItem)
    _ai.Add(Attribute)

    SetAttributeList()
  End Sub
  Public Sub AddStyleItem(ByVal Style As StyleItem)
    'If Not IsNothing(_si) Then
    '  ReDim Preserve _si(_si.Length)
    'Else
    '  ReDim _si(0)
    'End If
    '_si(_si.Length - 1) = Style
    If IsNothing(_si) Then _si = New List(Of StyleItem)
    _si.Add(Style)

    SetAttributeList()
  End Sub

  Public Sub New(ByVal AttributeKeys As String(), ByVal AttributeValues As String(),
                 ByVal StyleKeys As String(), ByVal StyleValues As String())
    If Not IsNothing(AttributeKeys) Then
      If Not IsNothing(AttributeValues) Then
        If AttributeKeys.Length = AttributeValues.Length Then
          For i = 0 To AttributeKeys.Length - 1 Step 1
            AddAttribute(New AttributeItem(AttributeKeys(i), AttributeValues(i)))
          Next
        Else
          Throw New ArgumentException("Attribute List cannot have uneven Keys and Values...")
        End If
      Else
        Throw New ArgumentException("Attribute List cannot have uneven Keys and Values...")
      End If
    End If
    If Not IsNothing(StyleKeys) Then
      If Not IsNothing(StyleValues) Then
        If StyleKeys.Length = StyleValues.Length Then
          For i = 0 To StyleKeys.Length - 1 Step 1
            AddStyleItem(New StyleItem(StyleKeys(i), StyleValues(i)))
          Next
        Else
          Throw New ArgumentException("Style List cannot have uneven Keys and Values...")
        End If
      Else
        Throw New ArgumentException("Style List cannot have uneven Keys and Values...")
      End If
    End If
    SetAttributeList()
  End Sub
  Public Sub New(ByVal AttributeItems As AttributeItem(), ByVal StyleItems As StyleItem())
    If Not IsNothing(AttributeItems) Then
      For Each ai As AttributeItem In AttributeItems
        AddAttribute(ai)
      Next
    End If
    If Not IsNothing(StyleItems) Then
      For Each si As StyleItem In StyleItems
        AddStyleItem(si)
      Next
    End If
    SetAttributeList()
  End Sub
  Public Sub New(ByVal ItemKeys As String(), ByVal ItemValues As String(), Optional ByVal IsStyle As Boolean = False)
    If IsStyle Then
      If Not IsNothing(ItemKeys) Then
        If Not IsNothing(ItemValues) Then
          If ItemKeys.Length = ItemValues.Length Then
            For i = 0 To ItemKeys.Length - 1 Step 1
              AddStyleItem(New StyleItem(ItemKeys(i), ItemValues(i)))
            Next
          Else
            Throw New ArgumentException("Style List cannot have uneven Keys and Values...")
          End If
        Else
          Throw New ArgumentException("Style List cannot have uneven Keys and Values...")
        End If
      End If
    Else
      If Not IsNothing(ItemKeys) Then
        If Not IsNothing(ItemValues) Then
          If ItemKeys.Length = ItemValues.Length Then
            For i = 0 To ItemKeys.Length - 1 Step 1
              AddAttribute(New AttributeItem(ItemKeys(i), ItemValues(i)))
            Next
          Else
            Throw New ArgumentException("Attribute List cannot have uneven Keys and Values...")
          End If
        Else
          Throw New ArgumentException("Attribute List cannot have uneven Keys and Values...")
        End If
      End If
    End If
    SetAttributeList()
  End Sub
  Public Sub New(ByVal AttributeItems As AttributeItem())
    If Not IsNothing(AttributeItems) Then
      For Each ai As AttributeItem In AttributeItems
        AddAttribute(ai)
      Next
    End If
    SetAttributeList()
  End Sub
  Public Sub New(ByVal StyleItems As StyleItem())
    If Not IsNothing(StyleItems) Then
      For Each si As StyleItem In StyleItems
        AddStyleItem(si)
      Next
    End If
    SetAttributeList()
  End Sub


  Public Sub SetAttributeList()
    _attr = New StringBuilder
    If Not IsNothing(_ai) Then
      For Each ai As AttributeItem In _ai
        _attr.Append(" " & ai.ToString)
      Next
    End If
    If Not IsNothing(_si) Then
      _attr.Append(" style=" & Chr(34))
      For Each si As StyleItem In _si
        _attr.Append(si.ToString)
      Next
      _attr.Append(Chr(34))
    End If
  End Sub
  Public Class AttributeItem
    Private _key, _val As String

    Public Property Key As String
      Get
        Return _key
      End Get
      Set(value As String)
        _key = value
      End Set
    End Property
    Public Property Value As String
      Get
        Return _val
      End Get
      Set(value As String)
        _val = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _key & "=" & Chr(34) & _val & Chr(34)
    End Function

    Public Sub New(ByVal Key As String, ByVal Value As String)
      _key = Key
      _val = Value
    End Sub
  End Class
  Public Class StyleItem
    Private _key, _val As String

    Public Property Key As String
      Get
        Return _key
      End Get
      Set(value As String)
        _key = value
      End Set
    End Property
    Public Property Value As String
      Get
        Return _val
      End Get
      Set(value As String)
        _val = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return _key & ": " & _val & ";"
    End Function

    Public Sub New(ByVal Key As String, ByVal Value As String)
      _key = Key
      _val = Value
    End Sub
  End Class
End Class
Public Module SharedFunctions
  Friend _safeChars As Boolean = False
  Public BadChars() As String = {"&", Chr(34), "'", "<", ">"}
  Public GoodChars() As String = {"&amp;", "&quot;", "&apos;", "&lt;", "&gt;"}
  Public HTMLTags() As String = {"body", "section", "nav", "aside", "h1", "h2", _
                                 "h3", "h4", "h5", "h6", "header", "footer", "address", _
                                 "main", "p", "hr", "pre", "blockquote", "ol", "ul", _
                                 "li", "dl", "dt", "dd", "figure", "figcaption", "div", _
                                 "a", "em", "strong", "s", "cite", "q", "dfn", "abbr", _
                                 "data", "time", "code", "var", "samp", "kbd", "sub", _
                                 "sup", "i", "b", "u", "mark", "ruby", "rt", "rp", "bdi", _
                                 "bdo", "span", "br", "wbr", "ins", "del", "img", "iframe", _
                                 "embed", "object", "param", "video", "audio", "source", _
                                 "track", "canvas", "map", "area", "svg", "math", "table", _
                                 "caption", "colgroup", "col", "tbody", "thead", "tfoot", _
                                 "tr", "td", "th", "form", "fieldset", "legend", "label", _
                                 "input", "button", "select", "datalist", "optgroup", _
                                 "option", "textarea", "keygen", "output", "progress", _
                                 "meter", "details", "summary", "menuitem", "menu", "html", _
                                 "head", "title", "base", "link", "meta", "style", "font"}
  'Private _style = " style=''"
  ''' <summary>
  ''' Searches for reserved words for HTML and replaces the carrots with appropriate meta characters.
  ''' </summary>
  ''' <param name="InputLine">Incoming inner text.</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function ReplaceBadChars(ByVal InputLine As String) As String
    If _safeChars Then
      'Replace HTML markup characters with viewable alternatatives
      If Not String.IsNullOrEmpty(InputLine) Then
        For i = 0 To BadChars.Length - 1 Step 1
          If InputLine.Contains(BadChars(i)) Then
            If InputLine.Contains("<") And InputLine.Contains(">") Then
              'Verify carrots aren't just HTML Tags, then replace as necessary
              Dim Flags() As String = Split(InputLine, "<")
              'Isolate tags
              Dim blnFlag As Boolean
              For n = 0 To Flags.Length - 1 Step 1
                If String.IsNullOrEmpty(Flags(n)) Then
                  Continue For
                ElseIf Not Flags(n).Contains(">") Then
                  Continue For
                ElseIf Flags(n).Contains(">") And Not Flags(n).Contains("<") Then
                  Flags(n) = "<" & Flags(n)
                End If
                'Compare to HTML Tags, assume it's not
                blnFlag = True
                For Each tag As String In HTMLTags
                  If Flags(n).StartsWith("<" & tag & " ") Or Flags(n).StartsWith("<" & tag & ">") Or Flags(n).StartsWith("</" & tag & ">") Then
                    blnFlag = False
                    'No need to continue if Tag is validated
                    Exit For
                  End If
                Next
                'if flag is thrown(default state), then replace input with good characters
                If blnFlag Then
                  InputLine = InputLine.Replace(Flags(n), Flags(n).Replace(BadChars(3), GoodChars(3)).Replace(BadChars(4), GoodChars(4)))
                End If
              Next
            Else
              'Replace bad characters
              Try
                InputLine = InputLine.Replace(BadChars(i), GoodChars(i))
              Catch ex As Exception
                Throw New ApplicationException("{HTML}ReplaceBadChars2: Catch=" & ex.Message)
              End Try
            End If
          End If
        Next
      End If
    End If
    Return InputLine
  End Function
  ' ''' <summary>
  ' ''' Returns a reformatted HTML element innertext with specified anchor (<a></a>) tags. Specify HREF and Id in AttributeList
  ' ''' </summary>
  ' ''' <param name="Attributes">Used to specify values for HREF, ID, TARGET, etc.</param>
  ' ''' <param name="InputText">Original Inner Text</param>
  ' ''' <returns></returns>
  ' ''' <remarks></remarks>
  'Public Function IncludeAnchor(ByVal Attributes As AttributeList, ByVal InputText As String) As String
  '  Return "<a" & Attributes.tostring & ">" & InputText '& "</a>"
  'End Function
End Module
