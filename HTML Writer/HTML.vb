Imports System.Drawing
Imports System.Text

Public Class HTMLWriter
  Implements IDisposable

  Const LargeStringSize As Integer = 100000
  Const MediumStringSize As Integer = 1000
  Const SmallStringSize As Integer = 100
  Private Shared str_html As StringBuilder

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
      If value.IndexOf("</html>") >= 0 Then
        str_html = New StringBuilder(LargeStringSize)
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
    Return HTMLMarkup
  End Function

  ''' <summary>
  ''' Creates a new instance of an HTML Document
  ''' </summary>
  ''' <remarks></remarks>
  Public Sub New(Optional ByVal SafetyMode As Boolean = True)
    _safeChars = SafetyMode

    IsInitialized()
  End Sub

  Public Function IsInitialized() As Boolean
    If str_html Is Nothing Then
      'Set first html tag
      str_html = New StringBuilder(LargeStringSize)
      str_html.Append("<!DOCTYPE html>").AppendLine("<html>").AppendLine("</html>")
    End If
    Return True
  End Function

  Public Sub AddMarkupToEndOfDocument(ByVal Input As String)
    IsInitialized() '' Check/ensure HTML is initialized
    str_html.Insert(str_html.Length - 9, Input) '' 9 because '</html>' plus vbcrlf which is two
  End Sub

  '' Series of methods to add markup to the current instance of an HTML Writer
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal RawHTML As String) As HTMLWriter
    Writer.AddToHTMLMarkup(RawHTML)
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLForm) As HTMLWriter
    Writer.AddToHTMLMarkup(HTMLObject)
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLHeader) As HTMLWriter
    Writer.AddToHTMLMarkup(HTMLObject)
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLTable) As HTMLWriter
    Writer.AddToHTMLMarkup(HTMLObject)
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLImageMap) As HTMLWriter
    Writer.AddToHTMLMarkup(HTMLObject)
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLList) As HTMLWriter
    Writer.AddToHTMLMarkup(HTMLObject)
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLImage) As HTMLWriter
    Writer.AddToHTMLMarkup(HTMLObject)
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLCanvas) As HTMLWriter
    Writer.AddToHTMLMarkup(HTMLObject)
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLParagraph) As HTMLWriter
    Writer.AddToHTMLMarkup(HTMLObject)
    Return Writer
  End Operator
  Public Overloads Shared Operator +(ByVal Writer As HTMLWriter, ByVal HTMLObject As HTMLAnchor) As HTMLWriter
    Writer.AddToHTMLMarkup(HTMLObject)
    Return Writer
  End Operator

  Public Overloads Sub AddToHTMLMarkup(ByVal RawHTML As String)
    AddMarkupToEndOfDocument(RawHTML)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLForm)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLHeader)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLTable)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLImageMap)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLList)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLImage)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLCanvas)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLParagraph)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLAnchor)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLDiv)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLSpan)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLAudio)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLVideo)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLLabel)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLMeter)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLInput)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLProgress)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub
  Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLSelect)
    AddMarkupToEndOfDocument(Item.Markup)
  End Sub

  Public Sub AddBootstrapReference()
    AddMarkupToEndOfDocument("<script type='text/javascript' src='https://ajax.googleapis.com/ajax/libs/jquery/2.2.0/jquery.min.js'></script>")
    AddMarkupToEndOfDocument("<link href='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css' rel='stylesheet' integrity='sha256-7s5uDGW3AHqw6xtJmNNtr+OBRJUlgkNJEo78P4b0yRw= sha512-nNo+yCHEyn0smMxSswnf/OnX6/KwJuZTlNZBjauKhTK0c+zT+q5JOCx0UFhXQ6rJR9jg6Es8gPuD2uZcYDLqSw==' crossorigin='anonymous'/>")
    AddMarkupToEndOfDocument("<script type='text/javascript' src='https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js' integrity='sha256-KXn5puMvxCw+dAYznun+drMdG1IFl3agK0p/pqT9KAo= sha512-2e8qq0ETcfWRI4HJBzQiA3UoyFk6tbNyG+qSaIBZLyW9Xf3sWZHN/lxe9fTh1U45DpPf07yj94KsUHHWe4Yk1A==' crossorigin='anonymous'></script>")
  End Sub
  Public Sub AddSortTableClass()
    AddMarkupToEndOfDocument("<script type='text/javascript'>" & My.Resources.SortTable & vbLf & _
                    "document.addEventListener('DOMContentLoaded', function(event){" & vbLf & _
                    "var __tables = document.querySelectorAll('table');" & vbLf & _
                    "for (var len = __tables.length, n = 0; n < len; n++){" & vbLf & _
                    "var __tmpSortTable = new SortTableClass.SortTable(__tables[n]);" & vbLf & _
                    "__tmpSortTable.UpdateTableHTML(__tables[n]);" & vbLf & _
                    "}" & vbLf & _
                    "});</script>")
  End Sub

  ''' <summary>
  ''' Represents an instance of a series of TextBox controls bound within the FieldSet HTML Element.
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLForm
    Private _form As New StringBuilder
    Private _attr As AttributeList
    ''' <summary>
    ''' Get/Set the HTML Markup for the current instance of an HTML Form.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Markup As String
      Get
        Return _form.ToString
      End Get
    End Property
    ''' <summary>
    ''' Creates a new instance of the HTML Form object.
    ''' </summary>
    ''' <param name="TEXT">The FieldSet Legend. Otherwise recognized as the label for the form.</param>
    ''' <remarks></remarks>
    Public Sub New(Optional ByVal Text As String = "", Optional ByVal Attributes As AttributeList = Nothing)
      If Attributes IsNot Nothing Then
        _form = New StringBuilder("<fieldset")
        _form.Append(Attributes.ToString).Append("><legend>").Append(ReplaceBadChars(Text)).AppendLine("</legend></fieldset>")
      Else
        _form = New StringBuilder("<fieldset")
        _form.Append("<legend>").Append(ReplaceBadChars(Text)).AppendLine("</legend></fieldset>")
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
      If LabelAttributes IsNot Nothing Then
        If TextAttributes IsNot Nothing Then
          _form = _form.Replace("</fieldset>" & vbLf, "<span" & LabelAttributes.ToString & ">" & ReplaceBadChars(Label) & "</span><input" & TextAttributes.ToString & " disabled='disabled' value=" & Chr(34) & ReplaceBadChars(Value) & Chr(34) & "/><br/>" & vbLf & "</fieldset>" & vbLf)
        Else
          _form = _form.Replace("</fieldset>" & vbLf, "<span" & LabelAttributes.ToString & ">" & ReplaceBadChars(Label) & "</span><input disabled='disabled' value=" & Chr(34) & ReplaceBadChars(Value) & Chr(34) & "/><br/>" & vbLf & "</fieldset>" & vbLf)
        End If
      Else
        If TextAttributes IsNot Nothing Then
          _form = _form.Replace("</fieldset>" & vbLf, "<span>" & ReplaceBadChars(Label) & "</span><input" & TextAttributes.ToString & " disabled='disabled' value=" & Chr(34) & ReplaceBadChars(Value) & Chr(34) & "/><br/>" & vbLf & "</fieldset>" & vbLf)
        Else
          _form = _form.Replace("</fieldset>" & vbLf, "<span>" & ReplaceBadChars(Label) & "</span><input disabled='disabled' value=" & Chr(34) & ReplaceBadChars(Value) & Chr(34) & "/><br/>" & vbLf & "</fieldset>" & vbLf)
        End If
      End If
    End Sub
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Header element.
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLHeader
    Implements IDisposable
    Private _header As New StringBuilder(SmallStringSize)
    Private _attr As AttributeList
    Private _hs As HeaderSize
    Private _inner As String

    Public Property InnerText As String
      Get
        Return _inner
      End Get
      Set(value As String)
        _inner = value
        'SetHeader()
      End Set
    End Property
    Public ReadOnly Property Markup As String
      Get
        SetHeader()
        Return _header.ToString
      End Get
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
        'SetHeader()
      End Set
    End Property
    Public Property Size As HeaderSize
      Get
        Return _hs
      End Get
      Set(value As HeaderSize)
        _hs = value
        'SetHeader()
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
      Return Markup
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
      _inner = InnerText
      'SetHeader()
    End Sub

    Public Sub SetHeader()
      _header = New StringBuilder(SmallStringSize)
      _header.Append("<" & GetHeaderSizeString(_hs))
      If _attr IsNot Nothing Then _header.Append(_attr.Markup)
      _header.Append(">").Append(ReplaceBadChars(_inner)).Append("</").Append(GetHeaderSizeString(_hs)).Append(">")
    End Sub
    Public Function GetHeaderSizeString(ByVal Header As HeaderSize) As String
      Return Header.ToString
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _header = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
          _inner = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

  End Class

  ''' <summary>
  ''' Represent an instance of an HTML Paragraph element.
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLParagraph
    Implements IDisposable
    Private _p As New StringBuilder(MediumStringSize)
    Private _attr As AttributeList
    Private _inner As New StringBuilder

    Public Property InnerHTML As String
      Get
        Return _inner.ToString
      End Get
      Set(value As String)
        _inner = New StringBuilder(MediumStringSize)
        _inner.Append(value)
        'SetParagraph()
      End Set
    End Property
    Public ReadOnly Property Markup As String
      Get
        SetParagraph()
        Return _p.ToString
      End Get
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
        'SetParagraph()
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function

    Public Sub New(ByVal InnerText As String, Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      _inner.Append(InnerText)
      'SetParagraph()
    End Sub

    Public Sub SetParagraph()
      _p = New StringBuilder(MediumStringSize)
      _p.Append("<p")
      If _attr IsNot Nothing Then _p.Append(_attr.Markup)
      _p.Append(">").Append(ReplaceBadChars(_inner.ToString)).Append("</p>")
    End Sub

    Public Sub Append(ByVal ExtraText As String)
      If _inner Is Nothing Then
        _inner = New StringBuilder(MediumStringSize)
      End If
      _inner.Append(ExtraText)
      'SetParagraph()
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _p = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
          _inner = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Table element.
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLTable
    Implements IDisposable

    Private _table As New StringBuilder(MediumStringSize)
    Private _attr As AttributeList
    Private _rws As New List(Of HTMLTableRow)

    ''' <summary>
    ''' Get/Set the HTML markup for the current instance of an HTML Table directly.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Markup As String
      Get
        SetTable()
        Return _table.ToString
      End Get
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
        'SetTable()
      End Set
    End Property
    Public ReadOnly Property Count As Integer
      Get
        If _rws IsNot Nothing Then
          Return _rws.Count
        Else
          Return -1
        End If
      End Get
    End Property
    Public Overrides Function ToString() As String
      Return Markup
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
      'SetTable()
    End Sub

    Public Sub SetTable()
      _table = New StringBuilder(MediumStringSize)
      Dim thead, tbody As StringBuilder
      thead = New StringBuilder(SmallStringSize)
      tbody = New StringBuilder(MediumStringSize)
      thead.AppendLine("<thead>")
      tbody.AppendLine("<tbody>")

      _table.Append("<table")
      If _attr IsNot Nothing Then _table.Append(_attr.Markup)
      _table.AppendLine(">")
      If _rws IsNot Nothing Then
        For i = 0 To _rws.Count - 1 Step 1
          If _rws(i).CellType = HTMLTableCell.CellType.Header Then
            thead.AppendLine(_rws(i).Markup)
          Else
            tbody.AppendLine(_rws(i).Markup)
          End If
        Next
      End If
      thead.AppendLine("</thead>")
      tbody.AppendLine("</tbody>")
      _table.AppendLine(thead.ToString)
      _table.AppendLine(tbody.ToString)
      _table.AppendLine("</table>")
    End Sub

    Public Sub AddTableRow(ByVal Row As HTMLTableRow)
      If _rws Is Nothing Then _rws = New List(Of HTMLTableRow)
      _rws.Add(Row)
      'SetTable()
    End Sub

    ''' <summary>
    ''' Represents the instance of an HTML Table Row.
    ''' </summary>
    ''' <remarks></remarks>
    Class HTMLTableRow
      Implements IDisposable
      Private _tr As New StringBuilder(SmallStringSize)
      Private _attr As AttributeList
      Private _clType As HTMLTableCell.CellType
      Private _cls As New List(Of HTMLTableCell)

      Public ReadOnly Property Cells As HTMLTableCell()
        Get
          Return _cls.ToArray
        End Get
      End Property
      Public ReadOnly Property CellType As HTMLTableCell.CellType
        Get
          Return _clType
        End Get
      End Property
      ''' <summary>
      ''' Get/Set the HTML markup for the current instance of an HTML Table Row directly.
      ''' </summary>
      ''' <value></value>
      ''' <returns></returns>
      ''' <remarks></remarks>
      Public Property Markup As String
        Get
          SetTableRow()
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
          'SetTableRow()
        End Set
      End Property
      Public ReadOnly Property Count As Integer
        Get
          If _cls IsNot Nothing Then
            Return _cls.Count
          Else
            Return -1
          End If
        End Get
      End Property
      Public Overrides Function ToString() As String
        Return Markup
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
        'SetTableRow()
      End Sub

      Public Sub SetTableRow()
        _tr = New StringBuilder(SmallStringSize)
        _tr.Append("<tr")
        If _attr IsNot Nothing Then _tr.Append(_attr.Markup)
        _tr.AppendLine(">")
        If _cls IsNot Nothing Then
          For i = 0 To _cls.Count - 1 Step 1
            _tr.AppendLine(_cls(i).Markup)
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
        'SetTableRow()
      End Sub
      Public Overloads Sub AddTableCell(ByVal Cell As HTMLTable.HTMLTableCell)
        If _cls Is Nothing Then _cls = New List(Of HTMLTableCell)
        _cls.Add(Cell)
        _clType = Cell.Type
        'SetTableRow()
      End Sub

#Region "IDisposable Support"
      Private disposedValue As Boolean ' To detect redundant calls

      ' IDisposable
      Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
          If disposing Then
            ' TODO: dispose managed state (managed objects).
            _tr = Nothing
            If _attr IsNot Nothing Then
              _attr.Dispose()
            End If
            _clType = Nothing
            _cls = Nothing
          End If

          ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
          ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
      End Sub

      ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
      Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(False)
        MyBase.Finalize()
      End Sub

      ' This code added by Visual Basic to correctly implement the disposable pattern.
      Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
      End Sub
#End Region

    End Class
    ''' <summary>
    ''' Represents the instance of an HTML Table Cell
    ''' </summary>
    ''' <remarks></remarks>
    Class HTMLTableCell
      Implements IDisposable

      Private _td As New StringBuilder
      Private _attr As AttributeList
      Private _ct As CellType
      Private _inner As New StringBuilder

      Public Enum CellType
        Header
        Row
      End Enum
      Public Property InnerHTML As String
        Get
          Return _inner.ToString
        End Get
        Set(value As String)
          _inner = New StringBuilder
          _inner.Append(value)
          'SetTableCell()
        End Set
      End Property
      Public ReadOnly Property Type As CellType
        Get
          Return _ct
        End Get
      End Property
      Public ReadOnly Property Markup As String
        Get
          SetTableCell()
          Return _td.ToString
        End Get
      End Property
      Public Property AttributeList As AttributeList
        Get
          Return _attr
        End Get
        Set(value As AttributeList)
          _attr = value
          'SetTableCell()
        End Set
      End Property
      Public Overrides Function ToString() As String
        Return Markup
      End Function

      Public Sub New(ByVal InnerText As String, ByVal CellType As CellType, Optional ByVal Attributes As AttributeList = Nothing)
        _attr = Attributes
        _ct = CellType
        _inner.Append(InnerText)
        'SetTableCell()
      End Sub

      Public Function SetTableCell() As String
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
        If _attr IsNot Nothing Then
          _td.Append("<" & ct & _attr.Markup)
        Else
          _td.Append("<" & ct)
        End If
        _td.Append(">" & ReplaceBadChars(InnerHTML) & "</" & ct & ">")
        Return _td.ToString
      End Function

#Region "IDisposable Support"
      Private disposedValue As Boolean ' To detect redundant calls

      ' IDisposable
      Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
          If disposing Then
            ' TODO: dispose managed state (managed objects).
            _td = Nothing
            If _attr IsNot Nothing Then
              _attr.Dispose()
            End If
            _ct = Nothing
            _inner = Nothing
          End If

          ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
          ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
      End Sub

      ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
      Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(False)
        MyBase.Finalize()
      End Sub

      ' This code added by Visual Basic to correctly implement the disposable pattern.
      Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
      End Sub
#End Region

    End Class

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _table = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
          _rws = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

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
      If (_img Is Nothing) Or (_map Is Nothing) Then
        Throw New ApplicationException("{HTML}CreateImageMap: HTMLImageMap must of have all properties set. {ImageUrl,ImageWidth,ImageHeight,Map}")
      Else
        SetImageMap()
      End If
    End Sub
    Public Sub SetImageMap()
      If (_img Is Nothing) Or (_map Is Nothing) Then
        Throw New ApplicationException("{HTML}CreateImageMap: HTMLImageMap must of have all properties set. {ImageUrl,ImageWidth,ImageHeight,Map}")
      Else
        _imgmap.Append("<img")
        If _attr IsNot Nothing Then _imgmap.Append(_attr.Markup)
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
      If _map Is Nothing Then
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
      If _map Is Nothing Then
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
    Implements IDisposable

    Private _list As New StringBuilder(MediumStringSize)
    Private _attr As AttributeList
    Private _ltype As ListType
    Private _lis As New List(Of ListItem)

    ''' <summary>
    ''' Get the raw HTML markup for the current instance of an HTML List.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Markup As String
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
        SetList()
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
        If _lis IsNot Nothing Then
          Return _lis.Count
        Else
          Return -1
        End If
      End Get
    End Property
    Public Overrides Function ToString() As String
      Return Markup
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
      'SetList()
    End Sub

    Public Sub AddListItem(ByVal ListItem As ListItem)
      If _lis Is Nothing Then _lis = New List(Of ListItem)
      _lis.Add(ListItem)
      'SetList()
    End Sub
    Public Sub SetList()
      _list = New StringBuilder(MediumStringSize)
      _list.Append("<" & GetListTypeTag(_ltype))
      If _attr IsNot Nothing Then _list.Append(_attr.Markup)
      _list.AppendLine(">")
      If _lis IsNot Nothing Then
        For i = 0 To _lis.Count - 1 Step 1
          _list.AppendLine(_lis(i).Markup)
        Next
      End If
      _list.AppendLine("</" & GetListTypeTag(_ltype) & ">")
    End Sub

    Public Class ListItem
      Implements IDisposable

      Private _li As StringBuilder
      Private _attr As AttributeList
      Private _inner As StringBuilder

      Public ReadOnly Property Markup As String
        Get
          SetListItem()
          Return _li.ToString
        End Get
      End Property
      Public Property InnerHTML As String
        Get
          Return _inner.ToString
        End Get
        Set(value As String)
          _inner = New StringBuilder(value)
          SetListItem()
        End Set
      End Property
      Public Property AttributeList As AttributeList
        Get
          Return _attr
        End Get
        Set(value As AttributeList)
          _attr = value
          SetListItem()
        End Set
      End Property
      Public Overrides Function ToString() As String
        Return Markup
      End Function

      Public Sub New(ByVal InnerHTML As String, Optional ByVal Attributes As AttributeList = Nothing)
        _attr = Attributes
        _inner = New StringBuilder(InnerHTML)
        'SetListItem(InnerHTML)
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
        If _attr IsNot Nothing Then _li.Append(_attr.Markup)
        _li.Append(">" & ReplaceBadChars(_inner.ToString) & "</li>")
      End Sub
      Public Sub AddInnerHTML(ByVal InnerHTML As String)
        If _inner Is Nothing Then
          _inner = New StringBuilder(InnerHTML)
          'SetListItem(InnerHTML)
        Else
          _inner.Append(InnerHTML)
          'SetListItem(_inner.ToString)
        End If
      End Sub

#Region "IDisposable Support"
      Private disposedValue As Boolean ' To detect redundant calls

      ' IDisposable
      Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
          If disposing Then
            ' TODO: dispose managed state (managed objects).
            _li = Nothing
            If _attr IsNot Nothing Then
              _attr.Dispose()
            End If
            _inner = Nothing
          End If

          ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
          ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
      End Sub

      ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
      Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(False)
        MyBase.Finalize()
      End Sub

      ' This code added by Visual Basic to correctly implement the disposable pattern.
      Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
      End Sub
#End Region

    End Class

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _list = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
          _ltype = Nothing
          _lis = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Image.
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLImage
    Implements IDisposable

    Private _img As New StringBuilder
    Private _src As String
    Private _attr As AttributeList

    Public ReadOnly Property Markup As String
      Get
        SetImage()
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
      Return Markup
    End Function
    Public Property Source As String
      Get
        Return _src
      End Get
      Set(value As String)
        _src = value
      End Set
    End Property

    ''' <summary>
    ''' Creates a new instance of the HTML Header object. 
    ''' This object serves as a Heading or Label in the layout of the HTML Document.
    ''' </summary>
    ''' <param name="Source"></param>
    ''' <param name="Attributes"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Source As String, Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      _src = Source
      'SetImage(Source)
    End Sub

    Public Sub SetImage(Optional ByVal Source As String = "")
      If Not String.IsNullOrEmpty(Source) Then _src = Source
      _img = New StringBuilder
      _img.Append("<img")
      If _attr IsNot Nothing Then _img.Append(_attr.Markup)
      _img.Append(" src=" & Chr(34) & ReplaceBadChars(_src) & Chr(34) & " />")
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _img = Nothing
          _src = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Canvas
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLCanvas
    Implements IDisposable

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
        SetCanvas()
        Return _cnv.ToString
      End Get
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function

    Public Sub New(ByVal ID As String, Optional ByVal Attributes As AttributeList = Nothing)
      _id = ID
      _attr = Attributes
      'SetCanvas()
    End Sub

    Public Sub SetCanvas()
      _cnv = New StringBuilder
      _cnv.Append("<canvas")
      If _attr IsNot Nothing Then _cnv.Append(_attr.Markup)
      _cnv.Append(" id=" & Chr(34) & _id & Chr(34) & ">This browser does not appear to support the HTML Canvas tag...</canvas>")
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _cnv = Nothing
          _id = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Anchor
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLAnchor
    Implements IDisposable

    Private _a As New StringBuilder
    Private _attr As AttributeList
    Private _name, _href, _targetFrame As String
    Private _target As TargetType
    Private _inner As New StringBuilder

    ''' <summary>
    ''' Get/Set the HTML markup for the current instance of an HTML Anchor directly.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Markup As String
      Get
        SetAnchor()
        Return _a.ToString
      End Get
    End Property
    Public Property Name As String
      Get
        Return _name
      End Get
      Set(value As String)
        _name = value
        'SetAnchor()
      End Set
    End Property
    Public Property InnerHTML As String
      Get
        Return _inner.ToString
      End Get
      Set(value As String)
        _inner = New StringBuilder
        _inner.Append(value)
        'SetAnchor()
      End Set
    End Property
    Public Property HREF As String
      Get
        Return _href
      End Get
      Set(value As String)
        _href = value
        'SetAnchor()
      End Set
    End Property
    Public Property Target As TargetType
      Get
        Return _target
      End Get
      Set(value As TargetType)
        _target = value
        'SetAnchor()
      End Set
    End Property
    Public Property TargetFrameName As String
      Get
        Return _targetFrame
      End Get
      Set(value As String)
        _targetFrame = value
        'SetAnchor()
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
        'SetAnchor()
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function

    Public Sub New(ByVal InnerText As String, Optional ByVal Name As String = "", Optional ByVal HREF As String = "", Optional ByVal Target As TargetType = TargetType.Self, Optional ByVal TargetFrame As String = "", Optional ByVal Attributes As AttributeList = Nothing)
      _name = Name
      _href = HREF
      _target = Target
      _targetFrame = TargetFrame
      _attr = Attributes
      _inner.Append(InnerText)
      'SetAnchor()
    End Sub

    Public Sub SetAnchor()
      If _a.Length > 0 Then _a = _a.Remove(0, _a.Length - 1)
      _a.Append("<a")
      If _attr IsNot Nothing Then _a.Append(_attr.Markup & "")
      _a.Append(" name='" & _name & "'")
      If Not String.IsNullOrEmpty(_href) Then
        _a.Append(" href=" & Chr(34) & _href & Chr(34))
        If Not String.IsNullOrEmpty(_targetFrame) Then
          _target = TargetType.Frame
          _a.Append(" target=" & Chr(34) & _targetFrame & Chr(34))
        Else
          If _target >= 0 Then
            _a.Append(" target=" & Chr(34) & GetTargetTypeString(_target) & Chr(34))
          End If
        End If
      End If
      _a.AppendLine(">" & ReplaceBadChars(_inner.ToString) & "</a>")
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

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _a = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
          _name = Nothing
          _href = Nothing
          _targetFrame = Nothing
          _target = Nothing
          _inner = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Input
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLInput
    Implements IDisposable

    Private _input As New StringBuilder
    Private _attr As AttributeList
    Private _type As InputType

    Public ReadOnly Property Markup As String
      Get
        SetInput()
        Return _input.ToString
      End Get
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
        'SetInput()
      End Set
    End Property
    Public Property Type As InputType
      Get
        Return _type
      End Get
      Set(value As InputType)
        _type = value
        'SetInput()
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function

    Public Sub New(ByVal Type As InputType, Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      _type = Type
      'SetInput()
    End Sub

    Public Sub SetInput()
      _input = New StringBuilder
      _input.Append("<input type=" & Chr(34) & InputTypeString(_type) & Chr(34))
      If _attr IsNot Nothing Then _input.Append(_attr.Markup)
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

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _input = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
          _type = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Label
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLLabel
    Implements IDisposable

    Private _label As New StringBuilder
    Private _attr As AttributeList
    Private _inner As String

    Public ReadOnly Property Markup As String
      Get
        SetLabel()
        Return _label.ToString
      End Get
    End Property
    Public Property InnerHTML As String
      Get
        Return _inner.ToString
      End Get
      Set(value As String)
        _inner = value
        'SetLabel()
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
        'SetLabel()
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function

    Public Sub New(ByVal InnerText As String, Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      _inner = InnerText
      'SetLabel()
    End Sub

    Public Sub SetLabel()
      _label = New StringBuilder
      _label.Append("<label")
      If _attr IsNot Nothing Then _label.Append(_attr.Markup)
      _label.Append(">" & ReplaceBadChars(_inner) & "</label>")
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _label = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
          _inner = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Select
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLSelect
    Implements IDisposable

    Private _select As New StringBuilder
    Private _attr As AttributeList
    Private _ops As New List(Of HTMLOption)

    Public ReadOnly Property Markup As String
      Get
        SetSelect()
        Return _select.ToString
      End Get
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
        'SetSelect()
      End Set
    End Property
    Public Property Options As HTMLOption()
      Get
        Return _ops.ToArray
      End Get
      Set(value As HTMLOption())
        _ops = New List(Of HTMLOption)
        _ops.AddRange(value)
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function
    Public Overloads Shared Operator +(ByVal HTMLSelect As HTMLSelect, ByVal NewOption As HTMLOption) As HTMLSelect
      HTMLSelect.AddOption(NewOption)
      Return HTMLSelect
    End Operator

    Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      'SetSelect()
    End Sub

    Public Sub SetSelect()
      _select = New StringBuilder
      _select.Append("<select")
      If Not _attr Is Nothing Then _select.Append(_attr.Markup)
      _select.AppendLine(">")
      If Not _ops Is Nothing Then
        For i = 0 To _ops.Count - 1 Step 1
          _select.AppendLine(vbTab & _ops(i).ToString)
        Next
      End If
      _select.AppendLine("</select>")
    End Sub
    Public Sub AddOption(ByVal NewOption As HTMLOption)
      If _ops Is Nothing Then _ops = New List(Of HTMLOption)
      _ops.Add(NewOption)
      'SetSelect()
    End Sub

    Public Class HTMLOption
      Implements IDisposable

      Private _option As StringBuilder
      Private _attr As AttributeList
      Private _val As String
      Private _inner As String

      Public ReadOnly Property Markup As String
        Get
          SetOption()
          Return _option.ToString
        End Get
      End Property
      Public Property InnerHTML As String
        Get
          Return _inner
        End Get
        Set(value As String)
          _inner = value
          'SetOption()
        End Set
      End Property
      Public Property Value As String
        Get
          Return _val
        End Get
        Set(value As String)
          _val = value
          'SetOption()
        End Set
      End Property
      Public Property AttributeList As AttributeList
        Get
          Return _attr
        End Get
        Set(value As AttributeList)
          _attr = value
          'SetOption()
        End Set
      End Property
      Public Overrides Function ToString() As String
        Return Markup
      End Function

      Public Sub New(ByVal InnerText As String, Optional ByVal OptionalValue As String = "", Optional ByVal Attributes As AttributeList = Nothing)
        _attr = Attributes
        _val = OptionalValue
        _inner = InnerText
        'SetOption()
      End Sub

      Public Sub SetOption()
        _option = New StringBuilder
        _option.Append("<option")
        If Not _attr Is Nothing Then _option.Append(_attr.Markup)
        _option.Append(" value=" & Chr(34) & _val & Chr(34) & ">" & ReplaceBadChars(_inner) & "</option>")
      End Sub

#Region "IDisposable Support"
      Private disposedValue As Boolean ' To detect redundant calls

      ' IDisposable
      Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
          If disposing Then
            ' TODO: dispose managed state (managed objects).
            _option = Nothing
            If _attr IsNot Nothing Then
              _attr.Dispose()
            End If
            _val = Nothing
            _inner = Nothing
          End If

          ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
          ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
      End Sub

      ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
      Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(False)
        MyBase.Finalize()
      End Sub

      ' This code added by Visual Basic to correctly implement the disposable pattern.
      Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
      End Sub
#End Region
    End Class

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _select = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
          _ops = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Progress
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLProgress
    Implements IDisposable

    Private _progress As New StringBuilder
    Private _attr As AttributeList

    Public ReadOnly Property Markup As String
      Get
        SetProgress()
        Return _progress.ToString
      End Get
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
        'SetProgress()
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function

    Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      'SetProgress()
    End Sub

    Public Sub SetProgress()
      _progress = New StringBuilder
      _progress.Append("<progress")
      If _attr IsNot Nothing Then _progress.Append(_attr.Markup)
      _progress.Append("></progress>")
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _progress = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Meter
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLMeter
    Implements IDisposable

    Private _meter As New StringBuilder
    Private _attr As AttributeList
    Private _inner As String

    Public ReadOnly Property Markup As String
      Get
        SetMeter()
        Return _meter.ToString
      End Get
    End Property
    Public Property InnerHTML As String
      Get
        Return _inner
      End Get
      Set(value As String)
        _inner = value
        'SetMeter()
      End Set
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
        'SetMeter()
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function

    Public Sub New(Optional ByVal InnerText As String = "", Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      _inner = InnerText
      'SetMeter()
    End Sub

    Public Sub SetMeter()
      _meter = New StringBuilder
      _meter.Append("<meter")
      If _attr IsNot Nothing Then _meter.Append(_attr.Markup)
      _meter.Append(">" & ReplaceBadChars(_inner) & "</meter>")
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _meter = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
          _inner = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Video
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLVideo
    Implements IDisposable

    Private _video As New StringBuilder
    Private _attr As AttributeList
    Private _srcs As New List(Of HTMLSource)

    Public ReadOnly Property Markup As String
      Get
        SetVideo()
        Return _video.ToString
      End Get
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
        'SetVideo()
      End Set
    End Property
    Public Property Sources As HTMLSource()
      Get
        Return _srcs.ToArray
      End Get
      Set(value As HTMLSource())
        _srcs = New List(Of HTMLSource)
        _srcs.AddRange(value)
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function
    Public Overloads Shared Operator +(ByVal Video As HTMLVideo, ByVal Source As HTMLSource) As HTMLVideo
      Video.AddSource(Source)
      Return Video
    End Operator

    Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      'SetVideo()
    End Sub

    Public Sub SetVideo()
      _video = New StringBuilder
      _video.Append("<video")
      If _attr IsNot Nothing Then _video.Append(_attr.Markup)
      _video.AppendLine(">")
      If _srcs IsNot Nothing Then
        For i = 0 To _srcs.Count - 1 Step 1
          _video.AppendLine(_srcs(i).Markup)
        Next
      End If
      _video.AppendLine("</video>")
    End Sub
    Public Sub AddSource(ByVal Source As HTMLSource)
      If _srcs Is Nothing Then _srcs = New List(Of HTMLSource)
      _srcs.Add(Source)
      'SetVideo()
    End Sub

    Class HTMLSource
      Implements IDisposable

      Private _source As New StringBuilder
      Private _attr As AttributeList

      Public ReadOnly Property Markup As String
        Get
          SetSource()
          Return _source.ToString
        End Get
      End Property
      Public Property AttributeList As AttributeList
        Get
          Return _attr
        End Get
        Set(value As AttributeList)
          _attr = value
          'SetSource()
        End Set
      End Property
      Public Overrides Function ToString() As String
        Return Markup
      End Function

      Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
        _attr = Attributes
        'SetSource()
      End Sub

      Public Sub SetSource()
        _source = New StringBuilder
        _source.Append("<source")
        If _attr IsNot Nothing Then _source.Append(_attr.Markup)
        _source.Append(">")
      End Sub

#Region "IDisposable Support"
      Private disposedValue As Boolean ' To detect redundant calls

      ' IDisposable
      Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
          If disposing Then
            ' TODO: dispose managed state (managed objects).
            _source = Nothing
            If _attr IsNot Nothing Then
              _attr.Dispose()
            End If
          End If

          ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
          ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
      End Sub

      ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
      Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(False)
        MyBase.Finalize()
      End Sub

      ' This code added by Visual Basic to correctly implement the disposable pattern.
      Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
      End Sub
#End Region
    End Class

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _video = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
          _srcs = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Audio
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLAudio
    Implements IDisposable

    Private _audio As New StringBuilder
    Private _attr As AttributeList
    Private _srcs As New List(Of HTMLSource)

    Public ReadOnly Property Markup As String
      Get
        SetAudio()
        Return _audio.ToString
      End Get
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
        'SetAudio()
      End Set
    End Property
    Public Property Sources As HTMLSource()
      Get
        Return _srcs.ToArray
      End Get
      Set(value As HTMLSource())
        _srcs = New List(Of HTMLSource)
        _srcs.AddRange(value)
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function
    Public Overloads Shared Operator +(ByVal Audio As HTMLAudio, ByVal Source As HTMLSource) As HTMLAudio
      Audio.AddSource(Source)
      Return Audio
    End Operator

    Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      'SetAudio()
    End Sub

    Public Sub SetAudio()
      _audio = New StringBuilder
      _audio.Append("<audio")
      If _attr IsNot Nothing Then _audio.Append(_attr.Markup)
      _audio.AppendLine(">")
      If _srcs IsNot Nothing Then
        For i = 0 To _srcs.Count - 1 Step 1
          _audio.AppendLine(_srcs(i).Markup)
        Next
      End If
      _audio.AppendLine("</audio>")
    End Sub
    Public Sub AddSource(ByVal Source As HTMLSource)
      If _srcs Is Nothing Then _srcs = New List(Of HTMLSource)
      _srcs.Add(Source)
      SetAudio()
    End Sub

    Class HTMLSource
      Implements IDisposable

      Private _source As New StringBuilder
      Private _attr As AttributeList

      Public ReadOnly Property Markup As String
        Get
          SetSource()
          Return _source.ToString
        End Get
      End Property
      Public Property AttributeList As AttributeList
        Get
          Return _attr
        End Get
        Set(value As AttributeList)
          _attr = value
          'SetSource()
        End Set
      End Property
      Public Overrides Function ToString() As String
        Return Markup
      End Function

      Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
        _attr = Attributes
        'SetSource()
      End Sub

      Public Sub SetSource()
        _source = New StringBuilder
        _source.Append("<source")
        If _attr IsNot Nothing Then _source.Append(_attr.Markup)
        _source.Append(">")
      End Sub

#Region "IDisposable Support"
      Private disposedValue As Boolean ' To detect redundant calls

      ' IDisposable
      Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
          If disposing Then
            ' TODO: dispose managed state (managed objects).
            _source = Nothing
            If _attr IsNot Nothing Then
              _attr.Dispose()
            End If
          End If

          ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
          ' TODO: set large fields to null.
        End If
        Me.disposedValue = True
      End Sub

      ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
      Protected Overrides Sub Finalize()
        ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        Dispose(False)
        MyBase.Finalize()
      End Sub

      ' This code added by Visual Basic to correctly implement the disposable pattern.
      Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
      End Sub
#End Region
    End Class

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _audio = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
          _srcs = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Div
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLDiv
    Implements IDisposable

    Private _div As New StringBuilder(MediumStringSize)
    Private _attr As AttributeList
    Private _inner As New StringBuilder(MediumStringSize)

    Public ReadOnly Property Markup As String
      Get
        SetDiv()
        Return _div.ToString
      End Get
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
        'SetDiv()
      End Set
    End Property
    Public Property InnerHTML As String
      Get
        Return _inner.ToString
      End Get
      Set(value As String)
        _inner = New StringBuilder
        _inner.Append(value)
        'SetDiv()
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function
    Public Overloads Shared Operator +(ByVal Div As HTMLDiv, ByVal ExtraHTML As String) As HTMLDiv
      Div.AppendDiv(ExtraHTML)
      Return Div
    End Operator

    Public Sub New(Optional ByVal InnerHTML As String = "", Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      _inner.Append(InnerHTML)
      'SetDiv()
    End Sub

    Public Sub SetDiv(Optional ByVal InnerHTML As String = "")
      If Not String.IsNullOrEmpty(InnerHTML) Then _inner = New StringBuilder(InnerHTML)
      _div = New StringBuilder(MediumStringSize)
      _div.Append("<div")
      If _attr IsNot Nothing Then _div.Append(_attr.Markup)
      _div.AppendLine(">")
      _div.AppendLine(_inner.ToString)
      _div.AppendLine("</div>")
    End Sub
    Public Sub AppendDiv(ByVal ExtraHTML As String)
      If _inner Is Nothing Then _inner = New StringBuilder(MediumStringSize)
      _inner.Append(ExtraHTML)
      'SetDiv()
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _div = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
          _inner = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class

  ''' <summary>
  ''' Represents an instance of an HTML Span
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLSpan
    Implements IDisposable

    Private _span As New StringBuilder(MediumStringSize)
    Private _attr As AttributeList
    Private _inner As New StringBuilder(MediumStringSize)

    Public ReadOnly Property Markup As String
      Get
        SetSpan()
        Return _span.ToString
      End Get
    End Property
    Public Property AttributeList As AttributeList
      Get
        Return _attr
      End Get
      Set(value As AttributeList)
        _attr = value
        'SetSpan()
      End Set
    End Property
    Public Property InnerHTML As String
      Get
        Return _inner.ToString
      End Get
      Set(value As String)
        _inner = New StringBuilder
        _inner.Append(value)
        'SetSpan()
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function
    Public Overloads Shared Operator +(ByVal Span As HTMLSpan, ByVal ExtraHTML As String) As HTMLSpan
      Span.AppendSpan(ExtraHTML)
      Return Span
    End Operator

    Public Sub New(Optional ByVal InnerHTML As String = "", Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      _inner.Append(InnerHTML)
      'SetSpan()
    End Sub

    Public Sub SetSpan(Optional ByVal InnerHTML As String = "")
      If Not String.IsNullOrEmpty(InnerHTML) Then _inner = New StringBuilder(InnerHTML)
      _span = New StringBuilder(MediumStringSize)
      _span.Append("<span")
      If _attr IsNot Nothing Then _span.Append(_attr.Markup)
      _span.AppendLine(">")
      _span.AppendLine(_inner.ToString)
      _span.AppendLine("</span>")
    End Sub
    Public Sub AppendSpan(ByVal ExtraHTML As String)
      If _inner Is Nothing Then _inner = New StringBuilder(MediumStringSize)
      _inner.Append(ExtraHTML)
      'SetSpan()
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _span = Nothing
          If _attr IsNot Nothing Then
            _attr.Dispose()
          End If
          _inner = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class

#Region "IDisposable Support"
  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not Me.disposedValue Then
      If disposing Then
        ' TODO: dispose managed state (managed objects).
        str_html = Nothing
      End If

      ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
      ' TODO: set large fields to null.
    End If
    Me.disposedValue = True
  End Sub

  ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
  Protected Overrides Sub Finalize()
    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    Dispose(False)
    MyBase.Finalize()
  End Sub

  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub
#End Region
End Class
Public Class AttributeList
  Implements IDisposable
  Private _attr As New StringBuilder
  Private _ai As List(Of AttributeItem)
  Private _si As List(Of StyleItem)
  Public ReadOnly Property Markup As String
    Get
      SetAttributeList()
      Return _attr.ToString
    End Get
  End Property
  Public Overrides Function ToString() As String
    Return Markup
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
    If _ai Is Nothing Then _ai = New List(Of AttributeItem)
    _ai.Add(Attribute)

    'SetAttributeList()
  End Sub
  Public Sub AddStyleItem(ByVal Style As StyleItem)
    If _si Is Nothing Then _si = New List(Of StyleItem)
    _si.Add(Style)

    'SetAttributeList()
  End Sub

  Public Sub New(ByVal AttributeKeys As String(), ByVal AttributeValues As String(),
                 ByVal StyleKeys As String(), ByVal StyleValues As String())
    If AttributeKeys IsNot Nothing Then
      If AttributeValues IsNot Nothing Then
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
    If StyleKeys IsNot Nothing Then
      If StyleValues IsNot Nothing Then
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
    'SetAttributeList()
  End Sub
  Public Sub New(ByVal AttributeItems As AttributeItem(), ByVal StyleItems As StyleItem())
    If AttributeItems IsNot Nothing Then
      For i = 0 To AttributeItems.Length - 1 Step 1
        AddAttribute(AttributeItems(i))
      Next
    End If
    If StyleItems IsNot Nothing Then
      For i = 0 To StyleItems.Length - 1 Step 1
        AddStyleItem(StyleItems(i))
      Next
    End If
    'SetAttributeList()
  End Sub
  Public Sub New(ByVal ItemKeys As String(), ByVal ItemValues As String(), Optional ByVal IsStyle As Boolean = False)
    If IsStyle Then
      If ItemKeys IsNot Nothing Then
        If ItemValues IsNot Nothing Then
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
      If ItemKeys IsNot Nothing Then
        If ItemValues IsNot Nothing Then
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
    'SetAttributeList()
  End Sub
  Public Sub New(ByVal AttributeItems As AttributeItem())
    If AttributeItems IsNot Nothing Then
      For i = 0 To AttributeItems.Length - 1 Step 1
        AddAttribute(AttributeItems(i))
      Next
    End If
    'SetAttributeList()
  End Sub
  Public Sub New(ByVal StyleItems As StyleItem())
    If StyleItems IsNot Nothing Then
      For i = 0 To StyleItems.Length - 1 Step 1
        AddStyleItem(StyleItems(i))
      Next
    End If
    'SetAttributeList()
  End Sub

  Public Sub SetAttributeList()
    _attr = New StringBuilder
    If _ai IsNot Nothing Then
      For i = 0 To _ai.Count - 1 Step 1
        _attr.Append(" " & _ai(i).ToString)
      Next
    End If
    If _si IsNot Nothing Then
      _attr.Append(" style=" & Chr(34))
      For i = 0 To _si.Count - 1 Step 1
        _attr.Append(_si(i).ToString)
      Next
      _attr.Append(Chr(34))
    End If
  End Sub
  Public Class AttributeItem
    Implements IDisposable
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

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _key = Nothing
          _val = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region
  End Class
  Public Class StyleItem
    Implements IDisposable
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

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _key = Nothing
          _val = Nothing
        End If

        ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
        ' TODO: set large fields to null.
      End If
      Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
    Protected Overrides Sub Finalize()
      ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
      Dispose(False)
      MyBase.Finalize()
    End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
      ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
      Dispose(True)
      GC.SuppressFinalize(Me)
    End Sub
#End Region

  End Class

#Region "IDisposable Support"
  Private disposedValue As Boolean ' To detect redundant calls

  ' IDisposable
  Protected Overridable Sub Dispose(disposing As Boolean)
    If Not Me.disposedValue Then
      If disposing Then
        ' TODO: dispose managed state (managed objects).
        _attr = Nothing
        _ai = Nothing
        _si = Nothing
      End If

      ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
      ' TODO: set large fields to null.
    End If
    Me.disposedValue = True
  End Sub

  ' TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
  Protected Overrides Sub Finalize()
    ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
    Dispose(False)
    MyBase.Finalize()
  End Sub

  ' This code added by Visual Basic to correctly implement the disposable pattern.
  Public Sub Dispose() Implements IDisposable.Dispose
    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    Dispose(True)
    GC.SuppressFinalize(Me)
  End Sub
#End Region
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
  'Public Function ReplaceBadChars(ByVal InputLine As String) As String
  '  If _safeChars Then
  '    Dim reg As System.Text.RegularExpressions.Regex
  '    Dim isTag As Boolean = False
  '    Dim mats As New List(Of RegularExpressions.Match)
  '    '' Reformat any good opening tags
  '    For i = 0 To HTMLTags.Length - 1 Step 1
  '      reg = New RegularExpressions.Regex("\<" & HTMLTags(i) & "(.*?)\>")
  '      InputLine = reg.Replace(InputLine, "|^|" & HTMLTags(i) & "$1|v|")
  '    Next
  '    '' Reformat any good closing tags
  '    For i = 0 To HTMLTags.Length - 1 Step 1
  '      reg = New RegularExpressions.Regex("\</" & HTMLTags(i) & "\>")
  '      InputLine = reg.Replace(InputLine, "|^|/" & HTMLTags(i) & "|v|")
  '    Next

  '    '' Reformat any bad tags
  '    reg = New RegularExpressions.Regex("\<(.*?)\>")
  '    InputLine = reg.Replace(InputLine, "&lt;$1&gt;")

  '    '' Reformat any reformatted tags back into HTML
  '    reg = New RegularExpressions.Regex("\|\^\|(.*?)\|v\|")
  '    InputLine = reg.Replace(InputLine, "<$1>")
  '  End If
  '  Return InputLine
  'End Function
  Public Function ReplaceBadChars(ByVal InputLine As String) As String
    If _safeChars Then
      Dim reg As System.Text.RegularExpressions.Regex
      '' Reformat any good opening tags
      For i = 0 To BadChars.Length - 1 Step 1
        reg = New RegularExpressions.Regex("(?<!</?[^>]*|&[^;]*)(\b" & BadChars(i) & "\b)")
        InputLine = reg.Replace(InputLine, GoodChars(i))
      Next
    End If
    Return InputLine
  End Function
End Module
