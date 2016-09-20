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

  ''' <summary>
  ''' Represents an instance of an HTML Object
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLObject
    Implements IDisposable

    Private _obj As New StringBuilder(LargeStringSize)
    Private _bs64 As New StringBuilder(LargeStringSize)
    Private _mime As MimeTypeAssociations
    Private _attr As AttributeList
    Private _inner As New StringBuilder(MediumStringSize)

    Public ReadOnly Property Markup As String
      Get
        SetObject()
        Return _obj.ToString
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
      Return Markup
    End Function
    Public Overloads Shared Operator +(ByVal Obj As HTMLObject, ByVal ExtraHTML As String) As HTMLObject
      Obj.AppendObject(ExtraHTML)
      Return Obj
    End Operator

    Public ReadOnly Property Mime As MimeTypeAssociations
      Get
        Return _mime
      End Get
    End Property

    Public Sub New(Optional ByVal URI As String = "", Optional ByVal InnerHTML As String = "", Optional ByVal Attributes As AttributeList = Nothing)
      If IO.File.Exists(URI) Then
        _bs64 = New StringBuilder(Convert.ToBase64String(IO.File.ReadAllBytes(URI)))
        _mime = GetMimeTypeAssociationFromFile(URI)
      End If
      _attr = Attributes
      _inner.Append(InnerHTML)
    End Sub

    Public Sub SetObject(Optional ByVal InnerHTML As String = "")
      If Not String.IsNullOrEmpty(InnerHTML) Then _inner = New StringBuilder(InnerHTML)
      _obj = New StringBuilder(LargeStringSize)
      _obj.Append("<object")
      If _attr IsNot Nothing Then
        '' Add the appropriate object data if not already available
        If Not IsNothing(_mime) And _bs64 IsNot Nothing Then
          If Not _attr.Contains("type") Then
            _attr.AddAttribute(New AttributeList.AttributeItem("type", _mime.MimeType))
          End If
          If Not _attr.Contains("data") Then
            _attr.AddAttribute(New AttributeList.AttributeItem("data", "data:" & _mime.MimeType & ";base64," & _bs64.ToString))
          End If
        End If
        _obj.Append(_attr.Markup)
      Else
        '' Add the appropriate object data if not already available
        If Not IsNothing(_mime) And _bs64 IsNot Nothing Then
          _attr = New AttributeList({"type", "data"}, {_mime.MimeType, "data:" & _mime.MimeType & ";base64," & _bs64.ToString})
          _obj.Append(_attr.Markup)
        End If
      End If

      _obj.AppendLine(">")
      _obj.AppendLine(_inner.ToString)
      _obj.AppendLine("</object>")
    End Sub
    Public Sub AppendObject(ByVal ExtraHTML As String)
      If _inner Is Nothing Then _inner = New StringBuilder(MediumStringSize)
      _inner.Append(ExtraHTML)
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _obj = Nothing
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
  ''' Represents an instance of an HTML Textarea
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLTextarea
    Implements IDisposable

    Private _textarea As New StringBuilder(MediumStringSize)
    Private _attr As AttributeList
    Private _inner As New StringBuilder(MediumStringSize)

    Public ReadOnly Property Markup As String
      Get
        SetTextarea()
        Return _textarea.ToString
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
      Return Markup
    End Function
    Public Overloads Shared Operator +(ByVal Textarea As HTMLTextarea, ByVal ExtraHTML As String) As HTMLTextarea
      Textarea.AppendTextarea(ExtraHTML)
      Return Textarea
    End Operator

    Public Sub New(Optional ByVal InnerText As String = "", Optional ByVal Attributes As AttributeList = Nothing)
      _attr = Attributes
      _inner.Append(InnerText)
    End Sub

    Public Sub SetTextarea(Optional ByVal InnerHTML As String = "")
      If Not String.IsNullOrEmpty(InnerHTML) Then _inner = New StringBuilder(InnerHTML)
      _textarea = New StringBuilder(MediumStringSize)
      _textarea.Append("<textarea")
      If _attr IsNot Nothing Then _textarea.Append(_attr.Markup)
      _textarea.AppendLine(">")
      _textarea.AppendLine(_inner.ToString)
      _textarea.AppendLine("</textarea>")
    End Sub
    Public Sub AppendTextarea(ByVal ExtraHTML As String)
      If _inner Is Nothing Then _inner = New StringBuilder(MediumStringSize)
      _inner.Append(ExtraHTML)
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _textarea = Nothing
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
  ''' Represents an instance of an HTML Data Island
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLDataIsland
    Implements IDisposable

    Private _xdoc As Xml.XmlDocument
    Private _id As String

    Public Property Document As Xml.XmlDocument
      Get
        Return _xdoc
      End Get
      Set(value As Xml.XmlDocument)
        _xdoc = value
      End Set
    End Property
    Public ReadOnly Property Markup As String
      Get
        If _xdoc IsNot Nothing Then
          Return String.Format("<string id={0}{1}{0} type={0}application/xml{0}>{2}</script>", {Chr(34), _id, _xdoc.OuterXml})
        Else
          Throw New NullReferenceException
        End If
      End Get
    End Property
    Public Property ClientID As String
      Get
        Return _id.ToString
      End Get
      Set(value As String)
        _id = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function

    Public Sub New(ByVal strId As String, Optional ByVal RefXmlDoc As Xml.XmlDocument = Nothing)
      _id = strId
      If RefXmlDoc Is Nothing Then
        _xdoc = New Xml.XmlDocument
      Else
        _xdoc = RefXmlDoc
      End If
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _xdoc = Nothing
          _id = Nothing
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
  ''' Represents an instance of an HTML Textarea
  ''' </summary>
  ''' <remarks></remarks>
  Class HTMLButton
    Implements IDisposable

    Private _button As New StringBuilder(SmallStringSize)
    Private _attr As AttributeList
    Private _inner As New StringBuilder(SmallStringSize)
    Private _bType As ButtonType

    Public ReadOnly Property Markup As String
      Get
        SetButton()
        Return _button.ToString
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
    Public Property InnerHTML As String
      Get
        Return _inner.ToString
      End Get
      Set(value As String)
        _inner = New StringBuilder
        _inner.Append(value)
      End Set
    End Property
    Public Property Type As ButtonType
      Get
        Return _bType
      End Get
      Set(value As ButtonType)
        _bType = value
      End Set
    End Property
    Public Overrides Function ToString() As String
      Return Markup
    End Function
    Public Overloads Shared Operator +(ByVal Button As HTMLButton, ByVal ExtraHTML As String) As HTMLButton
      Button.AppendButton(ExtraHTML)
      Return Button
    End Operator

    Public Enum ButtonType
      Button
      Submit
    End Enum

    Public Sub New(ByVal bType As ButtonType, Optional ByVal InnerText As String = "", Optional ByVal Attributes As AttributeList = Nothing)
      _bType = bType
      _attr = Attributes
      _inner.Append(InnerText)
    End Sub

    Public Sub SetButton(Optional ByVal InnerHTML As String = "")
      If Not String.IsNullOrEmpty(InnerHTML) Then _inner = New StringBuilder(InnerHTML)
      _button = New StringBuilder(SmallStringSize)
      _button.Append("<button type=" & Chr(34) & _bType.ToString.ToLower & Chr(34))
      If _attr IsNot Nothing Then _button.Append(_attr.Markup)
      _button.AppendLine(">")
      _button.AppendLine(_inner.ToString)
      _button.AppendLine("</button>")
    End Sub
    Public Sub AppendButton(ByVal ExtraHTML As String)
      If _inner Is Nothing Then _inner = New StringBuilder(SmallStringSize)
      _inner.Append(ExtraHTML)
    End Sub

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
        If disposing Then
          ' TODO: dispose managed state (managed objects).
          _button = Nothing
          _bType = Nothing
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

  Public Structure MimeTypeAssociations
    Private _name, _str, _ext As String

    Public ReadOnly Property MimeName As String
      Get
        Return _name
      End Get
    End Property
    Public ReadOnly Property MimeType As String
      Get
        Return _str
      End Get
    End Property
    Public ReadOnly Property MimeExtension As String
      Get
        Return _ext
      End Get
    End Property
    Public ReadOnly Property MimePrefix As String
      Get
        Return _str.Remove(_str.IndexOf("/"))
      End Get
    End Property
    Public ReadOnly Property MimeSuffix As String
      Get
        Return _str.Remove(0, _str.IndexOf("/") + 1)
      End Get
    End Property

    Public Sub New(ByVal Name As String, ByVal Type As String, ByVal Extension As String)
      _name = Name
      _str = Type
      _ext = Extension
    End Sub
  End Structure

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

  Public Function Contains(ByVal Key As String, Optional ByVal AsAttribute As Boolean = True) As Boolean
    If AsAttribute Then
      For i = 0 To _ai.Count - 1 Step 1
        If String.Equals(_ai(i).Key, Key, StringComparison.OrdinalIgnoreCase) Then
          Return True
        End If
      Next
    Else
      For i = 0 To _si.Count - 1 Step 1
        If String.Equals(_si(i).Key, Key, StringComparison.OrdinalIgnoreCase) Then
          Return True
        End If
      Next
    End If
    Return False
  End Function

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
  Public MimeTypes As HTMLWriter.MimeTypeAssociations() = {
  New HTMLWriter.MimeTypeAssociations("3D Crossword Plugin", "application/vnd.hzn-3d-crossword", "x3d"),
New HTMLWriter.MimeTypeAssociations("3GP", "video/3gpp", "3gp"),
New HTMLWriter.MimeTypeAssociations("3GP2", "video/3gpp2", "3g2"),
New HTMLWriter.MimeTypeAssociations("3GPP MSEQ File", "application/vnd.mseq", "mseq"),
New HTMLWriter.MimeTypeAssociations("3M Post It Notes", "application/vnd.3m.post-it-notes", "pwn"),
New HTMLWriter.MimeTypeAssociations("3rd Generation Partnership Project - Pic Large", "application/vnd.3gpp.pic-bw-large", "plb"),
New HTMLWriter.MimeTypeAssociations("3rd Generation Partnership Project - Pic Small", "application/vnd.3gpp.pic-bw-small", "psb"),
New HTMLWriter.MimeTypeAssociations("3rd Generation Partnership Project - Pic Var", "application/vnd.3gpp.pic-bw-var", "pvb"),
New HTMLWriter.MimeTypeAssociations("3rd Generation Partnership Project - Transaction Capabilities Application Part", "application/vnd.3gpp2.tcap", "tcap"),
New HTMLWriter.MimeTypeAssociations("7-Zip", "application/x-7z-compressed", "7z"),
New HTMLWriter.MimeTypeAssociations("AbiWord", "application/x-abiword", "abw"),
New HTMLWriter.MimeTypeAssociations("Ace Archive", "application/x-ace-compressed", "ace"),
New HTMLWriter.MimeTypeAssociations("Active Content Compression", "application/vnd.americandynamics.acc", "acc"),
New HTMLWriter.MimeTypeAssociations("ACU Cobol", "application/vnd.acucobol", "acu"),
New HTMLWriter.MimeTypeAssociations("ACU Cobol", "application/vnd.acucorp", "atc"),
New HTMLWriter.MimeTypeAssociations("Adaptive differential pulse-code modulation", "audio/adpcm", "adp"),
New HTMLWriter.MimeTypeAssociations("Adobe (Macropedia) Authorware - Binary File", "application/x-authorware-bin", "aab"),
New HTMLWriter.MimeTypeAssociations("Adobe (Macropedia) Authorware - Map", "application/x-authorware-map", "aam"),
New HTMLWriter.MimeTypeAssociations("Adobe (Macropedia) Authorware - Segment File", "application/x-authorware-seg", "aas"),
New HTMLWriter.MimeTypeAssociations("Adobe AIR Application", "application/vnd.adobe.air-application-installer-package+zip", "air"),
New HTMLWriter.MimeTypeAssociations("Adobe Flash", "application/x-shockwave-flash", "swf"),
New HTMLWriter.MimeTypeAssociations("Adobe Flex Project", "application/vnd.adobe.fxp", "fxp"),
New HTMLWriter.MimeTypeAssociations("Adobe Portable Document Format", "application/pdf", "pdf"),
New HTMLWriter.MimeTypeAssociations("Adobe PostScript Printer Description File Format", "application/vnd.cups-ppd", "ppd"),
New HTMLWriter.MimeTypeAssociations("Adobe Shockwave Player", "application/x-director", "dir"),
New HTMLWriter.MimeTypeAssociations("Adobe XML Data Package", "application/vnd.adobe.xdp+xml", "xdp"),
New HTMLWriter.MimeTypeAssociations("Adobe XML Forms Data Format", "application/vnd.adobe.xfdf", "xfdf"),
New HTMLWriter.MimeTypeAssociations("Advanced Audio Coding (AAC)", "audio/x-aac", "aac"),
New HTMLWriter.MimeTypeAssociations("Ahead AIR Application", "application/vnd.ahead.space", "ahead"),
New HTMLWriter.MimeTypeAssociations("AirZip FileSECURE", "application/vnd.airzip.filesecure.azf", "azf"),
New HTMLWriter.MimeTypeAssociations("AirZip FileSECURE", "application/vnd.airzip.filesecure.azs", "azs"),
New HTMLWriter.MimeTypeAssociations("Amazon Kindle eBook format", "application/vnd.amazon.ebook", "azw"),
New HTMLWriter.MimeTypeAssociations("AmigaDE", "application/vnd.amiga.ami", "ami"),
New HTMLWriter.MimeTypeAssociations("Andrew Toolkit", "application/andrew-inset", "N/A"),
New HTMLWriter.MimeTypeAssociations("Android Package Archive", "application/vnd.android.package-archive", "apk"),
New HTMLWriter.MimeTypeAssociations("ANSER-WEB Terminal Client - Certificate Issue", "application/vnd.anser-web-certificate-issue-initiation", "cii"),
New HTMLWriter.MimeTypeAssociations("ANSER-WEB Terminal Client - Web Funds Transfer", "application/vnd.anser-web-funds-transfer-initiation", "fti"),
New HTMLWriter.MimeTypeAssociations("Antix Game Player", "application/vnd.antix.game-component", "atx"),
New HTMLWriter.MimeTypeAssociations("Apple Installer Package", "application/vnd.apple.installer+xml", "mpkg"),
New HTMLWriter.MimeTypeAssociations("Applixware", "application/applixware", "aw"),
New HTMLWriter.MimeTypeAssociations("Archipelago Lesson Player", "application/vnd.hhe.lesson-player", "les"),
New HTMLWriter.MimeTypeAssociations("Arista Networks Software Image", "application/vnd.aristanetworks.swi", "swi"),
New HTMLWriter.MimeTypeAssociations("Assembler Source File", "text/x-asm", "s"),
New HTMLWriter.MimeTypeAssociations("Atom Publishing Protocol", "application/atomcat+xml", "atomcat"),
New HTMLWriter.MimeTypeAssociations("Atom Publishing Protocol Service Document", "application/atomsvc+xml", "atomsvc"),
New HTMLWriter.MimeTypeAssociations("Atom Syndication Format", "application/atom+xml", "atom"),
New HTMLWriter.MimeTypeAssociations("Attribute Certificate", "application/pkix-attr-cert", "ac"),
New HTMLWriter.MimeTypeAssociations("Audio Interchange File Format", "audio/x-aiff", "aif"),
New HTMLWriter.MimeTypeAssociations("Audio Video Interleave (AVI)", "video/x-msvideo", "avi"),
New HTMLWriter.MimeTypeAssociations("Audiograph", "application/vnd.audiograph", "aep"),
New HTMLWriter.MimeTypeAssociations("AutoCAD DXF", "image/vnd.dxf", "dxf"),
New HTMLWriter.MimeTypeAssociations("Autodesk Design Web Format (DWF)", "model/vnd.dwf", "dwf"),
New HTMLWriter.MimeTypeAssociations("BAS Partitur Format", "text/plain-bas", "par"),
New HTMLWriter.MimeTypeAssociations("Binary CPIO Archive", "application/x-bcpio", "bcpio"),
New HTMLWriter.MimeTypeAssociations("Binary Data", "application/octet-stream", "bin"),
New HTMLWriter.MimeTypeAssociations("Bitmap Image File", "image/bmp", "bmp"),
New HTMLWriter.MimeTypeAssociations("BitTorrent", "application/x-bittorrent", "torrent"),
New HTMLWriter.MimeTypeAssociations("Blackberry COD File", "application/vnd.rim.cod", "cod"),
New HTMLWriter.MimeTypeAssociations("Blueice Research Multipass", "application/vnd.blueice.multipass", "mpm"),
New HTMLWriter.MimeTypeAssociations("BMI Drawing Data Interchange", "application/vnd.bmi", "bmi"),
New HTMLWriter.MimeTypeAssociations("Bourne Shell Script", "application/x-sh", "sh"),
New HTMLWriter.MimeTypeAssociations("BTIF", "image/prs.btif", "btif"),
New HTMLWriter.MimeTypeAssociations("BusinessObjects", "application/vnd.businessobjects", "rep"),
New HTMLWriter.MimeTypeAssociations("Bzip Archive", "application/x-bzip", "bz"),
New HTMLWriter.MimeTypeAssociations("Bzip2 Archive", "application/x-bzip2", "bz2"),
New HTMLWriter.MimeTypeAssociations("C Shell Script", "application/x-csh", "csh"),
New HTMLWriter.MimeTypeAssociations("C Source File", "text/x-c", "c"),
New HTMLWriter.MimeTypeAssociations("CambridgeSoft Chem Draw", "application/vnd.chemdraw+xml", "cdxml"),
New HTMLWriter.MimeTypeAssociations("Cascading Style Sheets (CSS)", "text/css", "css"),
New HTMLWriter.MimeTypeAssociations("ChemDraw eXchange file", "chemical/x-cdx", "cdx"),
New HTMLWriter.MimeTypeAssociations("Chemical Markup Language", "chemical/x-cml", "cml"),
New HTMLWriter.MimeTypeAssociations("Chemical Style Markup Language", "chemical/x-csml", "csml"),
New HTMLWriter.MimeTypeAssociations("CIM Database", "application/vnd.contact.cmsg", "cdbcmsg"),
New HTMLWriter.MimeTypeAssociations("Claymore Data Files", "application/vnd.claymore", "cla"),
New HTMLWriter.MimeTypeAssociations("Clonk Game", "application/vnd.clonk.c4group", "c4g"),
New HTMLWriter.MimeTypeAssociations("Close Captioning - Subtitle", "image/vnd.dvb.subtitle", "sub"),
New HTMLWriter.MimeTypeAssociations("Cloud Data Management Interface (CDMI) - Capability", "application/cdmi-capability", "cdmia"),
New HTMLWriter.MimeTypeAssociations("Cloud Data Management Interface (CDMI) - Contaimer", "application/cdmi-container", "cdmic"),
New HTMLWriter.MimeTypeAssociations("Cloud Data Management Interface (CDMI) - Domain", "application/cdmi-domain", "cdmid"),
New HTMLWriter.MimeTypeAssociations("Cloud Data Management Interface (CDMI) - Object", "application/cdmi-object", "cdmio"),
New HTMLWriter.MimeTypeAssociations("Cloud Data Management Interface (CDMI) - Queue", "application/cdmi-queue", "cdmiq"),
New HTMLWriter.MimeTypeAssociations("ClueTrust CartoMobile - Config", "application/vnd.cluetrust.cartomobile-config", "c11amc"),
New HTMLWriter.MimeTypeAssociations("ClueTrust CartoMobile - Config Package", "application/vnd.cluetrust.cartomobile-config-pkg", "c11amz"),
New HTMLWriter.MimeTypeAssociations("CMU Image", "image/x-cmu-raster", "ras"),
New HTMLWriter.MimeTypeAssociations("COLLADA", "model/vnd.collada+xml", "dae"),
New HTMLWriter.MimeTypeAssociations("Comma-Seperated Values", "text/csv", "csv"),
New HTMLWriter.MimeTypeAssociations("Compact Pro", "application/mac-compactpro", "cpt"),
New HTMLWriter.MimeTypeAssociations("Compiled Wireless Markup Language (WMLC)", "application/vnd.wap.wmlc", "wmlc"),
New HTMLWriter.MimeTypeAssociations("Computer Graphics Metafile", "image/cgm", "cgm"),
New HTMLWriter.MimeTypeAssociations("CoolTalk", "x-conference/x-cooltalk", "ice"),
New HTMLWriter.MimeTypeAssociations("Corel Metafile Exchange (CMX)", "image/x-cmx", "cmx"),
New HTMLWriter.MimeTypeAssociations("CorelXARA", "application/vnd.xara", "xar"),
New HTMLWriter.MimeTypeAssociations("CosmoCaller", "application/vnd.cosmocaller", "cmc"),
New HTMLWriter.MimeTypeAssociations("CPIO Archive", "application/x-cpio", "cpio"),
New HTMLWriter.MimeTypeAssociations("CrickSoftware - Clicker", "application/vnd.crick.clicker", "clkx"),
New HTMLWriter.MimeTypeAssociations("CrickSoftware - Clicker - Keyboard", "application/vnd.crick.clicker.keyboard", "clkk"),
New HTMLWriter.MimeTypeAssociations("CrickSoftware - Clicker - Palette", "application/vnd.crick.clicker.palette", "clkp"),
New HTMLWriter.MimeTypeAssociations("CrickSoftware - Clicker - Template", "application/vnd.crick.clicker.template", "clkt"),
New HTMLWriter.MimeTypeAssociations("CrickSoftware - Clicker - Wordbank", "application/vnd.crick.clicker.wordbank", "clkw"),
New HTMLWriter.MimeTypeAssociations("Critical Tools - PERT Chart EXPERT", "application/vnd.criticaltools.wbs+xml", "wbs"),
New HTMLWriter.MimeTypeAssociations("CryptoNote", "application/vnd.rig.cryptonote", "cryptonote"),
New HTMLWriter.MimeTypeAssociations("Crystallographic Interchange Format", "chemical/x-cif", "cif"),
New HTMLWriter.MimeTypeAssociations("CrystalMaker Data Format", "chemical/x-cmdf", "cmdf"),
New HTMLWriter.MimeTypeAssociations("CU-SeeMe", "application/cu-seeme", "cu"),
New HTMLWriter.MimeTypeAssociations("CU-Writer", "application/prs.cww", "cww"),
New HTMLWriter.MimeTypeAssociations("Curl - Applet", "text/vnd.curl", "curl"),
New HTMLWriter.MimeTypeAssociations("Curl - Detached Applet", "text/vnd.curl.dcurl", "dcurl"),
New HTMLWriter.MimeTypeAssociations("Curl - Manifest File", "text/vnd.curl.mcurl", "mcurl"),
New HTMLWriter.MimeTypeAssociations("Curl - Source Code", "text/vnd.curl.scurl", "scurl"),
New HTMLWriter.MimeTypeAssociations("CURL Applet", "application/vnd.curl.car", "car"),
New HTMLWriter.MimeTypeAssociations("CURL Applet", "application/vnd.curl.pcurl", "pcurl"),
New HTMLWriter.MimeTypeAssociations("CustomMenu", "application/vnd.yellowriver-custom-menu", "cmp"),
New HTMLWriter.MimeTypeAssociations("Data Structure for the Security Suitability of Cryptographic Algorithms", "application/dssc+der", "dssc"),
New HTMLWriter.MimeTypeAssociations("Data Structure for the Security Suitability of Cryptographic Algorithms", "application/dssc+xml", "xdssc"),
New HTMLWriter.MimeTypeAssociations("Debian Package", "application/x-debian-package", "deb"),
New HTMLWriter.MimeTypeAssociations("DECE Audio", "audio/vnd.dece.audio", "uva"),
New HTMLWriter.MimeTypeAssociations("DECE Graphic", "image/vnd.dece.graphic", "uvi"),
New HTMLWriter.MimeTypeAssociations("DECE High Definition Video", "video/vnd.dece.hd", "uvh"),
New HTMLWriter.MimeTypeAssociations("DECE Mobile Video", "video/vnd.dece.mobile", "uvm"),
New HTMLWriter.MimeTypeAssociations("DECE MP4", "video/vnd.uvvu.mp4", "uvu"),
New HTMLWriter.MimeTypeAssociations("DECE PD Video", "video/vnd.dece.pd", "uvp"),
New HTMLWriter.MimeTypeAssociations("DECE SD Video", "video/vnd.dece.sd", "uvs"),
New HTMLWriter.MimeTypeAssociations("DECE Video", "video/vnd.dece.video", "uvv"),
New HTMLWriter.MimeTypeAssociations("Device Independent File Format (DVI)", "application/x-dvi", "dvi"),
New HTMLWriter.MimeTypeAssociations("Digital Siesmograph Networks - SEED Datafiles", "application/vnd.fdsn.seed", "seed"),
New HTMLWriter.MimeTypeAssociations("Digital Talking Book", "application/x-dtbook+xml", "dtb"),
New HTMLWriter.MimeTypeAssociations("Digital Talking Book - Resource File", "application/x-dtbresource+xml", "res"),
New HTMLWriter.MimeTypeAssociations("Digital Video Broadcasting", "application/vnd.dvb.ait", "ait"),
New HTMLWriter.MimeTypeAssociations("Digital Video Broadcasting", "application/vnd.dvb.service", "svc"),
New HTMLWriter.MimeTypeAssociations("Digital Winds Music", "audio/vnd.digital-winds", "eol"),
New HTMLWriter.MimeTypeAssociations("DjVu", "image/vnd.djvu", "djvu"),
New HTMLWriter.MimeTypeAssociations("Document Type Definition", "application/xml-dtd", "dtd"),
New HTMLWriter.MimeTypeAssociations("Dolby Meridian Lossless Packing", "application/vnd.dolby.mlp", "mlp"),
New HTMLWriter.MimeTypeAssociations("Doom Video Game", "application/x-doom", "wad"),
New HTMLWriter.MimeTypeAssociations("DPGraph", "application/vnd.dpgraph", "dpg"),
New HTMLWriter.MimeTypeAssociations("DRA Audio", "audio/vnd.dra", "dra"),
New HTMLWriter.MimeTypeAssociations("DreamFactory", "application/vnd.dreamfactory", "dfac"),
New HTMLWriter.MimeTypeAssociations("DTS Audio", "audio/vnd.dts", "dts"),
New HTMLWriter.MimeTypeAssociations("DTS High Definition Audio", "audio/vnd.dts.hd", "dtshd"),
New HTMLWriter.MimeTypeAssociations("DWG Drawing", "image/vnd.dwg", "dwg"),
New HTMLWriter.MimeTypeAssociations("DynaGeo", "application/vnd.dynageo", "geo"),
New HTMLWriter.MimeTypeAssociations("ECMAScript", "application/ecmascript", "es"),
New HTMLWriter.MimeTypeAssociations("EcoWin Chart", "application/vnd.ecowin.chart", "mag"),
New HTMLWriter.MimeTypeAssociations("EDMICS 2000", "image/vnd.fujixerox.edmics-mmr", "mmr"),
New HTMLWriter.MimeTypeAssociations("EDMICS 2000", "image/vnd.fujixerox.edmics-rlc", "rlc"),
New HTMLWriter.MimeTypeAssociations("Efficient XML Interchange", "application/exi", "exi"),
New HTMLWriter.MimeTypeAssociations("EFI Proteus", "application/vnd.proteus.magazine", "mgz"),
New HTMLWriter.MimeTypeAssociations("Electronic Publication", "application/epub+zip", "epub"),
New HTMLWriter.MimeTypeAssociations("Email Message", "message/rfc822", "eml"),
New HTMLWriter.MimeTypeAssociations("Enliven Viewer", "application/vnd.enliven", "nml"),
New HTMLWriter.MimeTypeAssociations("Express by Infoseek", "application/vnd.is-xpr", "xpr"),
New HTMLWriter.MimeTypeAssociations("eXtended Image File Format (XIFF)", "image/vnd.xiff", "xif"),
New HTMLWriter.MimeTypeAssociations("Extensible Forms Description Language", "application/vnd.xfdl", "xfdl"),
New HTMLWriter.MimeTypeAssociations("Extensible MultiModal Annotation", "application/emma+xml", "emma"),
New HTMLWriter.MimeTypeAssociations("EZPix Secure Photo Album", "application/vnd.ezpix-album", "ez2"),
New HTMLWriter.MimeTypeAssociations("EZPix Secure Photo Album", "application/vnd.ezpix-package", "ez3"),
New HTMLWriter.MimeTypeAssociations("FAST Search & Transfer ASA", "image/vnd.fst", "fst"),
New HTMLWriter.MimeTypeAssociations("FAST Search & Transfer ASA", "video/vnd.fvt", "fvt"),
New HTMLWriter.MimeTypeAssociations("FastBid Sheet", "image/vnd.fastbidsheet", "fbs"),
New HTMLWriter.MimeTypeAssociations("FCS Express Layout Link", "application/vnd.denovo.fcselayout-link", "fe_launch"),
New HTMLWriter.MimeTypeAssociations("Flash Video", "video/x-f4v", "f4v"),
New HTMLWriter.MimeTypeAssociations("Flash Video", "video/x-flv", "flv"),
New HTMLWriter.MimeTypeAssociations("FlashPix", "image/vnd.fpx", "fpx"),
New HTMLWriter.MimeTypeAssociations("FlashPix", "image/vnd.net-fpx", "npx"),
New HTMLWriter.MimeTypeAssociations("FLEXSTOR", "text/vnd.fmi.flexstor", "flx"),
New HTMLWriter.MimeTypeAssociations("FLI/FLC Animation Format", "video/x-fli", "fli"),
New HTMLWriter.MimeTypeAssociations("FluxTime Clip", "application/vnd.fluxtime.clip", "ftc"),
New HTMLWriter.MimeTypeAssociations("Forms Data Format", "application/vnd.fdf", "fdf"),
New HTMLWriter.MimeTypeAssociations("Fortran Source File", "text/x-fortran", "f"),
New HTMLWriter.MimeTypeAssociations("FrameMaker Interchange Format", "application/vnd.mif", "mif"),
New HTMLWriter.MimeTypeAssociations("FrameMaker Normal Format", "application/vnd.framemaker", "fm"),
New HTMLWriter.MimeTypeAssociations("FreeHand MX", "image/x-freehand", "fh"),
New HTMLWriter.MimeTypeAssociations("Friendly Software Corporation", "application/vnd.fsc.weblaunch", "fsc"),
New HTMLWriter.MimeTypeAssociations("Frogans Player", "application/vnd.frogans.fnc", "fnc"),
New HTMLWriter.MimeTypeAssociations("Frogans Player", "application/vnd.frogans.ltf", "ltf"),
New HTMLWriter.MimeTypeAssociations("Fujitsu - Xerox 2D CAD Data", "application/vnd.fujixerox.ddd", "ddd"),
New HTMLWriter.MimeTypeAssociations("Fujitsu - Xerox DocuWorks", "application/vnd.fujixerox.docuworks", "xdw"),
New HTMLWriter.MimeTypeAssociations("Fujitsu - Xerox DocuWorks Binder", "application/vnd.fujixerox.docuworks.binder", "xbd"),
New HTMLWriter.MimeTypeAssociations("Fujitsu Oasys", "application/vnd.fujitsu.oasys", "oas"),
New HTMLWriter.MimeTypeAssociations("Fujitsu Oasys", "application/vnd.fujitsu.oasys2", "oa2"),
New HTMLWriter.MimeTypeAssociations("Fujitsu Oasys", "application/vnd.fujitsu.oasys3", "oa3"),
New HTMLWriter.MimeTypeAssociations("Fujitsu Oasys", "application/vnd.fujitsu.oasysgp", "fg5"),
New HTMLWriter.MimeTypeAssociations("Fujitsu Oasys", "application/vnd.fujitsu.oasysprs", "bh2"),
New HTMLWriter.MimeTypeAssociations("FutureSplash Animator", "application/x-futuresplash", "spl"),
New HTMLWriter.MimeTypeAssociations("FuzzySheet", "application/vnd.fuzzysheet", "fzs"),
New HTMLWriter.MimeTypeAssociations("G3 Fax Image", "image/g3fax", "g3"),
New HTMLWriter.MimeTypeAssociations("GameMaker ActiveX", "application/vnd.gmx", "gmx"),
New HTMLWriter.MimeTypeAssociations("Gen-Trix Studio", "model/vnd.gtw", "gtw"),
New HTMLWriter.MimeTypeAssociations("Genomatix Tuxedo Framework", "application/vnd.genomatix.tuxedo", "txd"),
New HTMLWriter.MimeTypeAssociations("GeoGebra", "application/vnd.geogebra.file", "ggb"),
New HTMLWriter.MimeTypeAssociations("GeoGebra", "application/vnd.geogebra.tool", "ggt"),
New HTMLWriter.MimeTypeAssociations("Geometric Description Language (GDL)", "model/vnd.gdl", "gdl"),
New HTMLWriter.MimeTypeAssociations("GeoMetry Explorer", "application/vnd.geometry-explorer", "gex"),
New HTMLWriter.MimeTypeAssociations("GEONExT and JSXGraph", "application/vnd.geonext", "gxt"),
New HTMLWriter.MimeTypeAssociations("GeoplanW", "application/vnd.geoplan", "g2w"),
New HTMLWriter.MimeTypeAssociations("GeospacW", "application/vnd.geospace", "g3w"),
New HTMLWriter.MimeTypeAssociations("Ghostscript Font", "application/x-font-ghostscript", "gsf"),
New HTMLWriter.MimeTypeAssociations("Glyph Bitmap Distribution Format", "application/x-font-bdf", "bdf"),
New HTMLWriter.MimeTypeAssociations("GNU Tar Files", "application/x-gtar", "gtar"),
New HTMLWriter.MimeTypeAssociations("GNU Texinfo Document", "application/x-texinfo", "texinfo"),
New HTMLWriter.MimeTypeAssociations("Gnumeric", "application/x-gnumeric", "gnumeric"),
New HTMLWriter.MimeTypeAssociations("Google Earth - KML", "application/vnd.google-earth.kml+xml", "kml"),
New HTMLWriter.MimeTypeAssociations("Google Earth - Zipped KML", "application/vnd.google-earth.kmz", "kmz"),
New HTMLWriter.MimeTypeAssociations("GrafEq", "application/vnd.grafeq", "gqf"),
New HTMLWriter.MimeTypeAssociations("Graphics Interchange Format", "image/gif", "gif"),
New HTMLWriter.MimeTypeAssociations("Graphviz", "text/vnd.graphviz", "gv"),
New HTMLWriter.MimeTypeAssociations("Groove - Account", "application/vnd.groove-account", "gac"),
New HTMLWriter.MimeTypeAssociations("Groove - Help", "application/vnd.groove-help", "ghf"),
New HTMLWriter.MimeTypeAssociations("Groove - Identity Message", "application/vnd.groove-identity-message", "gim"),
New HTMLWriter.MimeTypeAssociations("Groove - Injector", "application/vnd.groove-injector", "grv"),
New HTMLWriter.MimeTypeAssociations("Groove - Tool Message", "application/vnd.groove-tool-message", "gtm"),
New HTMLWriter.MimeTypeAssociations("Groove - Tool Template", "application/vnd.groove-tool-template", "tpl"),
New HTMLWriter.MimeTypeAssociations("Groove - Vcard", "application/vnd.groove-vcard", "vcg"),
New HTMLWriter.MimeTypeAssociations("H.261", "video/h261", "h261"),
New HTMLWriter.MimeTypeAssociations("H.263", "video/h263", "h263"),
New HTMLWriter.MimeTypeAssociations("H.264", "video/h264", "h264"),
New HTMLWriter.MimeTypeAssociations("Hewlett Packard Instant Delivery", "application/vnd.hp-hpid", "hpid"),
New HTMLWriter.MimeTypeAssociations("Hewlett-Packard's WebPrintSmart", "application/vnd.hp-hps", "hps"),
New HTMLWriter.MimeTypeAssociations("Hierarchical Data Format", "application/x-hdf", "hdf"),
New HTMLWriter.MimeTypeAssociations("Hit'n'Mix", "audio/vnd.rip", "rip"),
New HTMLWriter.MimeTypeAssociations("Homebanking Computer Interface (HBCI)", "application/vnd.hbci", "hbci"),
New HTMLWriter.MimeTypeAssociations("HP Indigo Digital Press - Job Layout Languate", "application/vnd.hp-jlyt", "jlt"),
New HTMLWriter.MimeTypeAssociations("HP Printer Command Language", "application/vnd.hp-pcl", "pcl"),
New HTMLWriter.MimeTypeAssociations("HP-GL/2 and HP RTL", "application/vnd.hp-hpgl", "hpgl"),
New HTMLWriter.MimeTypeAssociations("HV Script", "application/vnd.yamaha.hv-script", "hvs"),
New HTMLWriter.MimeTypeAssociations("HV Voice Dictionary", "application/vnd.yamaha.hv-dic", "hvd"),
New HTMLWriter.MimeTypeAssociations("HV Voice Parameter", "application/vnd.yamaha.hv-voice", "hvp"),
New HTMLWriter.MimeTypeAssociations("Hydrostatix Master Suite", "application/vnd.hydrostatix.sof-data", "sfd-hdstx"),
New HTMLWriter.MimeTypeAssociations("Hyperstudio", "application/hyperstudio", "stk"),
New HTMLWriter.MimeTypeAssociations("Hypertext Application Language", "application/vnd.hal+xml", "hal"),
New HTMLWriter.MimeTypeAssociations("HyperText Markup Language (HTML)", "text/html", "html"),
New HTMLWriter.MimeTypeAssociations("IBM DB2 Rights Manager", "application/vnd.ibm.rights-management", "irm"),
New HTMLWriter.MimeTypeAssociations("IBM Electronic Media Management System - Secure Container", "application/vnd.ibm.secure-container", "sc"),
New HTMLWriter.MimeTypeAssociations("iCalendar", "text/calendar", "ics"),
New HTMLWriter.MimeTypeAssociations("ICC profile", "application/vnd.iccprofile", "icc"),
New HTMLWriter.MimeTypeAssociations("Icon Image", "image/x-icon", "ico"),
New HTMLWriter.MimeTypeAssociations("igLoader", "application/vnd.igloader", "igl"),
New HTMLWriter.MimeTypeAssociations("Image Exchange Format", "image/ief", "ief"),
New HTMLWriter.MimeTypeAssociations("ImmerVision PURE Players", "application/vnd.immervision-ivp", "ivp"),
New HTMLWriter.MimeTypeAssociations("ImmerVision PURE Players", "application/vnd.immervision-ivu", "ivu"),
New HTMLWriter.MimeTypeAssociations("IMS Networks", "application/reginfo+xml", "rif"),
New HTMLWriter.MimeTypeAssociations("In3D - 3DML", "text/vnd.in3d.3dml", "3dml"),
New HTMLWriter.MimeTypeAssociations("In3D - 3DML", "text/vnd.in3d.spot", "spot"),
New HTMLWriter.MimeTypeAssociations("Initial Graphics Exchange Specification (IGES)", "model/iges", "igs"),
New HTMLWriter.MimeTypeAssociations("Interactive Geometry Software", "application/vnd.intergeo", "i2g"),
New HTMLWriter.MimeTypeAssociations("Interactive Geometry Software Cinderella", "application/vnd.cinderella", "cdy"),
New HTMLWriter.MimeTypeAssociations("Intercon FormNet", "application/vnd.intercon.formnet", "xpw"),
New HTMLWriter.MimeTypeAssociations("International Society for Advancement of Cytometry", "application/vnd.isac.fcs", "fcs"),
New HTMLWriter.MimeTypeAssociations("Internet Protocol Flow Information Export", "application/ipfix", "ipfix"),
New HTMLWriter.MimeTypeAssociations("Internet Public Key Infrastructure - Certificate", "application/pkix-cert", "cer"),
New HTMLWriter.MimeTypeAssociations("Internet Public Key Infrastructure - Certificate Management Protocole", "application/pkixcmp", "pki"),
New HTMLWriter.MimeTypeAssociations("Internet Public Key Infrastructure - Certificate Revocation Lists", "application/pkix-crl", "crl"),
New HTMLWriter.MimeTypeAssociations("Internet Public Key Infrastructure - Certification Path", "application/pkix-pkipath", "pkipath"),
New HTMLWriter.MimeTypeAssociations("IOCOM Visimeet", "application/vnd.insors.igm", "igm"),
New HTMLWriter.MimeTypeAssociations("IP Unplugged Roaming Client", "application/vnd.ipunplugged.rcprofile", "rcprofile"),
New HTMLWriter.MimeTypeAssociations("iRepository / Lucidoc Editor", "application/vnd.irepository.package+xml", "irp"),
New HTMLWriter.MimeTypeAssociations("J2ME App Descriptor", "text/vnd.sun.j2me.app-descriptor", "jad"),
New HTMLWriter.MimeTypeAssociations("Java Archive", "application/java-archive", "jar"),
New HTMLWriter.MimeTypeAssociations("Java Bytecode File", "application/java-vm", "class"),
New HTMLWriter.MimeTypeAssociations("Java Network Launching Protocol", "application/x-java-jnlp-file", "jnlp"),
New HTMLWriter.MimeTypeAssociations("Java Serialized Object", "application/java-serialized-object", "ser"),
New HTMLWriter.MimeTypeAssociations("Java Source File", "text/x-java-source,java", "java"),
New HTMLWriter.MimeTypeAssociations("JavaScript", "application/javascript", "js"),
New HTMLWriter.MimeTypeAssociations("JavaScript Object Notation (JSON)", "application/json", "json"),
New HTMLWriter.MimeTypeAssociations("Joda Archive", "application/vnd.joost.joda-archive", "joda"),
New HTMLWriter.MimeTypeAssociations("JPEG 2000 Compound Image File Format", "video/jpm", "jpm"),
New HTMLWriter.MimeTypeAssociations("JPEG Image", "image/jpeg", "jpeg"),
New HTMLWriter.MimeTypeAssociations("JPEG Image", "image/jpeg", "jpg"),
New HTMLWriter.MimeTypeAssociations("JPGVideo", "video/jpeg", "jpgv"),
New HTMLWriter.MimeTypeAssociations("Kahootz", "application/vnd.kahootz", "ktz"),
New HTMLWriter.MimeTypeAssociations("Karaoke on Chipnuts Chipsets", "application/vnd.chipnuts.karaoke-mmd", "mmd"),
New HTMLWriter.MimeTypeAssociations("KDE KOffice Office Suite - Karbon", "application/vnd.kde.karbon", "karbon"),
New HTMLWriter.MimeTypeAssociations("KDE KOffice Office Suite - KChart", "application/vnd.kde.kchart", "chrt"),
New HTMLWriter.MimeTypeAssociations("KDE KOffice Office Suite - Kformula", "application/vnd.kde.kformula", "kfo"),
New HTMLWriter.MimeTypeAssociations("KDE KOffice Office Suite - Kivio", "application/vnd.kde.kivio", "flw"),
New HTMLWriter.MimeTypeAssociations("KDE KOffice Office Suite - Kontour", "application/vnd.kde.kontour", "kon"),
New HTMLWriter.MimeTypeAssociations("KDE KOffice Office Suite - Kpresenter", "application/vnd.kde.kpresenter", "kpr"),
New HTMLWriter.MimeTypeAssociations("KDE KOffice Office Suite - Kspread", "application/vnd.kde.kspread", "ksp"),
New HTMLWriter.MimeTypeAssociations("KDE KOffice Office Suite - Kword", "application/vnd.kde.kword", "kwd"),
New HTMLWriter.MimeTypeAssociations("Kenamea App", "application/vnd.kenameaapp", "htke"),
New HTMLWriter.MimeTypeAssociations("Kidspiration", "application/vnd.kidspiration", "kia"),
New HTMLWriter.MimeTypeAssociations("Kinar Applications", "application/vnd.kinar", "kne"),
New HTMLWriter.MimeTypeAssociations("Kodak Storyshare", "application/vnd.kodak-descriptor", "sse"),
New HTMLWriter.MimeTypeAssociations("Laser App Enterprise", "application/vnd.las.las+xml", "lasxml"),
New HTMLWriter.MimeTypeAssociations("LaTeX", "application/x-latex", "latex"),
New HTMLWriter.MimeTypeAssociations("Life Balance - Desktop Edition", "application/vnd.llamagraphics.life-balance.desktop", "lbd"),
New HTMLWriter.MimeTypeAssociations("Life Balance - Exchange Format", "application/vnd.llamagraphics.life-balance.exchange+xml", "lbe"),
New HTMLWriter.MimeTypeAssociations("Lightspeed Audio Lab", "application/vnd.jam", "jam"),
New HTMLWriter.MimeTypeAssociations("Lotus 1-2-3", "application/vnd.lotus-1-2-3", "123"),
New HTMLWriter.MimeTypeAssociations("Lotus Approach", "application/vnd.lotus-approach", "apr"),
New HTMLWriter.MimeTypeAssociations("Lotus Freelance", "application/vnd.lotus-freelance", "pre"),
New HTMLWriter.MimeTypeAssociations("Lotus Notes", "application/vnd.lotus-notes", "nsf"),
New HTMLWriter.MimeTypeAssociations("Lotus Organizer", "application/vnd.lotus-organizer", "org"),
New HTMLWriter.MimeTypeAssociations("Lotus Screencam", "application/vnd.lotus-screencam", "scm"),
New HTMLWriter.MimeTypeAssociations("Lotus Wordpro", "application/vnd.lotus-wordpro", "lwp"),
New HTMLWriter.MimeTypeAssociations("Lucent Voice", "audio/vnd.lucent.voice", "lvp"),
New HTMLWriter.MimeTypeAssociations("M3U (Multimedia Playlist)", "audio/x-mpegurl", "m3u"),
New HTMLWriter.MimeTypeAssociations("M4v", "video/x-m4v", "m4v"),
New HTMLWriter.MimeTypeAssociations("Macintosh BinHex 4.0", "application/mac-binhex40", "hqx"),
New HTMLWriter.MimeTypeAssociations("MacPorts Port System", "application/vnd.macports.portpkg", "portpkg"),
New HTMLWriter.MimeTypeAssociations("MapGuide DBXML", "application/vnd.osgeo.mapguide.package", "mgp"),
New HTMLWriter.MimeTypeAssociations("MARC Formats", "application/marc", "mrc"),
New HTMLWriter.MimeTypeAssociations("MARC21 XML Schema", "application/marcxml+xml", "mrcx"),
New HTMLWriter.MimeTypeAssociations("Material Exchange Format", "application/mxf", "mxf"),
New HTMLWriter.MimeTypeAssociations("Mathematica Notebook Player", "application/vnd.wolfram.player", "nbp"),
New HTMLWriter.MimeTypeAssociations("Mathematica Notebooks", "application/mathematica", "ma"),
New HTMLWriter.MimeTypeAssociations("Mathematical Markup Language", "application/mathml+xml", "mathml"),
New HTMLWriter.MimeTypeAssociations("Mbox database files", "application/mbox", "mbox"),
New HTMLWriter.MimeTypeAssociations("MedCalc", "application/vnd.medcalcdata", "mc1"),
New HTMLWriter.MimeTypeAssociations("Media Server Control Markup Language", "application/mediaservercontrol+xml", "mscml"),
New HTMLWriter.MimeTypeAssociations("MediaRemote", "application/vnd.mediastation.cdkey", "cdkey"),
New HTMLWriter.MimeTypeAssociations("Medical Waveform Encoding Format", "application/vnd.mfer", "mwf"),
New HTMLWriter.MimeTypeAssociations("Melody Format for Mobile Platform", "application/vnd.mfmp", "mfm"),
New HTMLWriter.MimeTypeAssociations("Mesh Data Type", "model/mesh", "msh"),
New HTMLWriter.MimeTypeAssociations("Metadata Authority Description Schema", "application/mads+xml", "mads"),
New HTMLWriter.MimeTypeAssociations("Metadata Encoding and Transmission Standard", "application/mets+xml", "mets"),
New HTMLWriter.MimeTypeAssociations("Metadata Object Description Schema", "application/mods+xml", "mods"),
New HTMLWriter.MimeTypeAssociations("Metalink", "application/metalink4+xml", "meta4"),
New HTMLWriter.MimeTypeAssociations("Micosoft PowerPoint - Macro-Enabled Template File", "application/vnd.ms-powerpoint.template.macroenabled.12", "potm"),
New HTMLWriter.MimeTypeAssociations("Micosoft Word - Macro-Enabled Document", "application/vnd.ms-word.document.macroenabled.12", "docm"),
New HTMLWriter.MimeTypeAssociations("Micosoft Word - Macro-Enabled Template", "application/vnd.ms-word.template.macroenabled.12", "dotm"),
New HTMLWriter.MimeTypeAssociations("Micro CADAM Helix D&D", "application/vnd.mcd", "mcd"),
New HTMLWriter.MimeTypeAssociations("Micrografx", "application/vnd.micrografx.flo", "flo"),
New HTMLWriter.MimeTypeAssociations("Micrografx iGrafx Professional", "application/vnd.micrografx.igx", "igx"),
New HTMLWriter.MimeTypeAssociations("MICROSEC e-Szign¢", "application/vnd.eszigno3+xml", "es3"),
New HTMLWriter.MimeTypeAssociations("Microsoft Access", "application/x-msaccess", "mdb"),
New HTMLWriter.MimeTypeAssociations("Microsoft Advanced Systems Format (ASF)", "video/x-ms-asf", "asf"),
New HTMLWriter.MimeTypeAssociations("Microsoft Application", "application/x-msdownload", "exe"),
New HTMLWriter.MimeTypeAssociations("Microsoft Artgalry", "application/vnd.ms-artgalry", "cil"),
New HTMLWriter.MimeTypeAssociations("Microsoft Cabinet File", "application/vnd.ms-cab-compressed", "cab"),
New HTMLWriter.MimeTypeAssociations("Microsoft Class Server", "application/vnd.ms-ims", "ims"),
New HTMLWriter.MimeTypeAssociations("Microsoft ClickOnce", "application/x-ms-application", "application"),
New HTMLWriter.MimeTypeAssociations("Microsoft Clipboard Clip", "application/x-msclip", "clp"),
New HTMLWriter.MimeTypeAssociations("Microsoft Document Imaging Format", "image/vnd.ms-modi", "mdi"),
New HTMLWriter.MimeTypeAssociations("Microsoft Embedded OpenType", "application/vnd.ms-fontobject", "eot"),
New HTMLWriter.MimeTypeAssociations("Microsoft Excel", "application/vnd.ms-excel", "xls"),
New HTMLWriter.MimeTypeAssociations("Microsoft Excel - Add-In File", "application/vnd.ms-excel.addin.macroenabled.12", "xlam"),
New HTMLWriter.MimeTypeAssociations("Microsoft Excel - Binary Workbook", "application/vnd.ms-excel.sheet.binary.macroenabled.12", "xlsb"),
New HTMLWriter.MimeTypeAssociations("Microsoft Excel - Macro-Enabled Template File", "application/vnd.ms-excel.template.macroenabled.12", "xltm"),
New HTMLWriter.MimeTypeAssociations("Microsoft Excel - Macro-Enabled Workbook", "application/vnd.ms-excel.sheet.macroenabled.12", "xlsm"),
New HTMLWriter.MimeTypeAssociations("Microsoft Html Help File", "application/vnd.ms-htmlhelp", "chm"),
New HTMLWriter.MimeTypeAssociations("Microsoft Information Card", "application/x-mscardfile", "crd"),
New HTMLWriter.MimeTypeAssociations("Microsoft Learning Resource Module", "application/vnd.ms-lrm", "lrm"),
New HTMLWriter.MimeTypeAssociations("Microsoft MediaView", "application/x-msmediaview", "mvb"),
New HTMLWriter.MimeTypeAssociations("Microsoft Money", "application/x-msmoney", "mny"),
New HTMLWriter.MimeTypeAssociations("Microsoft Office - OOXML - Presentation", "application/vnd.openxmlformats-officedocument.presentationml.presentation", "pptx"),
New HTMLWriter.MimeTypeAssociations("Microsoft Office - OOXML - Presentation (Slide)", "application/vnd.openxmlformats-officedocument.presentationml.slide", "sldx"),
New HTMLWriter.MimeTypeAssociations("Microsoft Office - OOXML - Presentation (Slideshow)", "application/vnd.openxmlformats-officedocument.presentationml.slideshow", "ppsx"),
New HTMLWriter.MimeTypeAssociations("Microsoft Office - OOXML - Presentation Template", "application/vnd.openxmlformats-officedocument.presentationml.template", "potx"),
New HTMLWriter.MimeTypeAssociations("Microsoft Office - OOXML - Spreadsheet", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "xlsx"),
New HTMLWriter.MimeTypeAssociations("Microsoft Office - OOXML - Spreadsheet Teplate", "application/vnd.openxmlformats-officedocument.spreadsheetml.template", "xltx"),
New HTMLWriter.MimeTypeAssociations("Microsoft Office - OOXML - Word Document", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "docx"),
New HTMLWriter.MimeTypeAssociations("Microsoft Office - OOXML - Word Document Template", "application/vnd.openxmlformats-officedocument.wordprocessingml.template", "dotx"),
New HTMLWriter.MimeTypeAssociations("Microsoft Office Binder", "application/x-msbinder", "obd"),
New HTMLWriter.MimeTypeAssociations("Microsoft Office System Release Theme", "application/vnd.ms-officetheme", "thmx"),
New HTMLWriter.MimeTypeAssociations("Microsoft OneNote", "application/onenote", "onetoc"),
New HTMLWriter.MimeTypeAssociations("Microsoft PlayReady Ecosystem", "audio/vnd.ms-playready.media.pya", "pya"),
New HTMLWriter.MimeTypeAssociations("Microsoft PlayReady Ecosystem Video", "video/vnd.ms-playready.media.pyv", "pyv"),
New HTMLWriter.MimeTypeAssociations("Microsoft PowerPoint", "application/vnd.ms-powerpoint", "ppt"),
New HTMLWriter.MimeTypeAssociations("Microsoft PowerPoint - Add-in file", "application/vnd.ms-powerpoint.addin.macroenabled.12", "ppam"),
New HTMLWriter.MimeTypeAssociations("Microsoft PowerPoint - Macro-Enabled Open XML Slide", "application/vnd.ms-powerpoint.slide.macroenabled.12", "sldm"),
New HTMLWriter.MimeTypeAssociations("Microsoft PowerPoint - Macro-Enabled Presentation File", "application/vnd.ms-powerpoint.presentation.macroenabled.12", "pptm"),
New HTMLWriter.MimeTypeAssociations("Microsoft PowerPoint - Macro-Enabled Slide Show File", "application/vnd.ms-powerpoint.slideshow.macroenabled.12", "ppsm"),
New HTMLWriter.MimeTypeAssociations("Microsoft Project", "application/vnd.ms-project", "mpp"),
New HTMLWriter.MimeTypeAssociations("Microsoft Publisher", "application/x-mspublisher", "pub"),
New HTMLWriter.MimeTypeAssociations("Microsoft Schedule+", "application/x-msschedule", "scd"),
New HTMLWriter.MimeTypeAssociations("Microsoft Silverlight", "application/x-silverlight-app", "xap"),
New HTMLWriter.MimeTypeAssociations("Microsoft Trust UI Provider - Certificate Trust Link", "application/vnd.ms-pki.stl", "stl"),
New HTMLWriter.MimeTypeAssociations("Microsoft Trust UI Provider - Security Catalog", "application/vnd.ms-pki.seccat", "cat"),
New HTMLWriter.MimeTypeAssociations("Microsoft Visio", "application/vnd.visio", "vsd"),
New HTMLWriter.MimeTypeAssociations("Microsoft Windows Media", "video/x-ms-wm", "wm"),
New HTMLWriter.MimeTypeAssociations("Microsoft Windows Media Audio", "audio/x-ms-wma", "wma"),
New HTMLWriter.MimeTypeAssociations("Microsoft Windows Media Audio Redirector", "audio/x-ms-wax", "wax"),
New HTMLWriter.MimeTypeAssociations("Microsoft Windows Media Audio/Video Playlist", "video/x-ms-wmx", "wmx"),
New HTMLWriter.MimeTypeAssociations("Microsoft Windows Media Player Download Package", "application/x-ms-wmd", "wmd"),
New HTMLWriter.MimeTypeAssociations("Microsoft Windows Media Player Playlist", "application/vnd.ms-wpl", "wpl"),
New HTMLWriter.MimeTypeAssociations("Microsoft Windows Media Player Skin Package", "application/x-ms-wmz", "wmz"),
New HTMLWriter.MimeTypeAssociations("Microsoft Windows Media Video", "video/x-ms-wmv", "wmv"),
New HTMLWriter.MimeTypeAssociations("Microsoft Windows Media Video Playlist", "video/x-ms-wvx", "wvx"),
New HTMLWriter.MimeTypeAssociations("Microsoft Windows Metafile", "application/x-msmetafile", "wmf"),
New HTMLWriter.MimeTypeAssociations("Microsoft Windows Terminal Services", "application/x-msterminal", "trm"),
New HTMLWriter.MimeTypeAssociations("Microsoft Word", "application/msword", "doc"),
New HTMLWriter.MimeTypeAssociations("Microsoft Wordpad", "application/x-mswrite", "wri"),
New HTMLWriter.MimeTypeAssociations("Microsoft Works", "application/vnd.ms-works", "wps"),
New HTMLWriter.MimeTypeAssociations("Microsoft XAML Browser Application", "application/x-ms-xbap", "xbap"),
New HTMLWriter.MimeTypeAssociations("Microsoft XML Paper Specification", "application/vnd.ms-xpsdocument", "xps"),
New HTMLWriter.MimeTypeAssociations("MIDI - Musical Instrument Digital Interface", "audio/midi", "mid"),
New HTMLWriter.MimeTypeAssociations("MiniPay", "application/vnd.ibm.minipay", "mpy"),
New HTMLWriter.MimeTypeAssociations("MO:DCA-P", "application/vnd.ibm.modcap", "afp"),
New HTMLWriter.MimeTypeAssociations("Mobile Information Device Profile", "application/vnd.jcp.javame.midlet-rms", "rms"),
New HTMLWriter.MimeTypeAssociations("MobileTV", "application/vnd.tmobile-livetv", "tmo"),
New HTMLWriter.MimeTypeAssociations("Mobipocket", "application/x-mobipocket-ebook", "prc"),
New HTMLWriter.MimeTypeAssociations("Mobius Management Systems - Basket file", "application/vnd.mobius.mbk", "mbk"),
New HTMLWriter.MimeTypeAssociations("Mobius Management Systems - Distribution Database", "application/vnd.mobius.dis", "dis"),
New HTMLWriter.MimeTypeAssociations("Mobius Management Systems - Policy Definition Language File", "application/vnd.mobius.plc", "plc"),
New HTMLWriter.MimeTypeAssociations("Mobius Management Systems - Query File", "application/vnd.mobius.mqy", "mqy"),
New HTMLWriter.MimeTypeAssociations("Mobius Management Systems - Script Language", "application/vnd.mobius.msl", "msl"),
New HTMLWriter.MimeTypeAssociations("Mobius Management Systems - Topic Index File", "application/vnd.mobius.txf", "txf"),
New HTMLWriter.MimeTypeAssociations("Mobius Management Systems - UniversalArchive", "application/vnd.mobius.daf", "daf"),
New HTMLWriter.MimeTypeAssociations("mod_fly / fly.cgi", "text/vnd.fly", "fly"),
New HTMLWriter.MimeTypeAssociations("Mophun Certificate", "application/vnd.mophun.certificate", "mpc"),
New HTMLWriter.MimeTypeAssociations("Mophun VM", "application/vnd.mophun.application", "mpn"),
New HTMLWriter.MimeTypeAssociations("Motion JPEG 2000", "video/mj2", "mj2"),
New HTMLWriter.MimeTypeAssociations("MPEG Audio", "audio/mpeg", "mpga"),
New HTMLWriter.MimeTypeAssociations("MPEG Url", "video/vnd.mpegurl", "mxu"),
New HTMLWriter.MimeTypeAssociations("MPEG Video", "video/mpeg", "mpeg"),
New HTMLWriter.MimeTypeAssociations("MPEG-21", "application/mp21", "m21"),
New HTMLWriter.MimeTypeAssociations("MPEG-4 Audio", "audio/mp4", "mp4a"),
New HTMLWriter.MimeTypeAssociations("MPEG-4 Video", "video/mp4", "mp4"),
New HTMLWriter.MimeTypeAssociations("MPEG4", "application/mp4", "mp4"),
New HTMLWriter.MimeTypeAssociations("Multimedia Playlist Unicode", "application/vnd.apple.mpegurl", "m3u8"),
New HTMLWriter.MimeTypeAssociations("MUsical Score Interpreted Code Invented for the ASCII designation of Notation", "application/vnd.musician", "mus"),
New HTMLWriter.MimeTypeAssociations("Muvee Automatic Video Editing", "application/vnd.muvee.style", "msty"),
New HTMLWriter.MimeTypeAssociations("MXML", "application/xv+xml", "mxml"),
New HTMLWriter.MimeTypeAssociations("N-Gage Game Data", "application/vnd.nokia.n-gage.data", "ngdat"),
New HTMLWriter.MimeTypeAssociations("N-Gage Game Installer", "application/vnd.nokia.n-gage.symbian.install", "n-gage"),
New HTMLWriter.MimeTypeAssociations("Navigation Control file for XML (for ePub)", "application/x-dtbncx+xml", "ncx"),
New HTMLWriter.MimeTypeAssociations("Network Common Data Form (NetCDF)", "application/x-netcdf", "nc"),
New HTMLWriter.MimeTypeAssociations("neuroLanguage", "application/vnd.neurolanguage.nlu", "nlu"),
New HTMLWriter.MimeTypeAssociations("New Moon Liftoff/DNA", "application/vnd.dna", "dna"),
New HTMLWriter.MimeTypeAssociations("NobleNet Directory", "application/vnd.noblenet-directory", "nnd"),
New HTMLWriter.MimeTypeAssociations("NobleNet Sealer", "application/vnd.noblenet-sealer", "nns"),
New HTMLWriter.MimeTypeAssociations("NobleNet Web", "application/vnd.noblenet-web", "nnw"),
New HTMLWriter.MimeTypeAssociations("Nokia Radio Application - Preset", "application/vnd.nokia.radio-preset", "rpst"),
New HTMLWriter.MimeTypeAssociations("Nokia Radio Application - Preset", "application/vnd.nokia.radio-presets", "rpss"),
New HTMLWriter.MimeTypeAssociations("Notation3", "text/n3", "n3"),
New HTMLWriter.MimeTypeAssociations("Novadigm's RADIA and EDM products", "application/vnd.novadigm.edm", "edm"),
New HTMLWriter.MimeTypeAssociations("Novadigm's RADIA and EDM products", "application/vnd.novadigm.edx", "edx"),
New HTMLWriter.MimeTypeAssociations("Novadigm's RADIA and EDM products", "application/vnd.novadigm.ext", "ext"),
New HTMLWriter.MimeTypeAssociations("NpGraphIt", "application/vnd.flographit", "gph"),
New HTMLWriter.MimeTypeAssociations("Nuera ECELP 4800", "audio/vnd.nuera.ecelp4800", "ecelp4800"),
New HTMLWriter.MimeTypeAssociations("Nuera ECELP 7470", "audio/vnd.nuera.ecelp7470", "ecelp7470"),
New HTMLWriter.MimeTypeAssociations("Nuera ECELP 9600", "audio/vnd.nuera.ecelp9600", "ecelp9600"),
New HTMLWriter.MimeTypeAssociations("Office Document Architecture", "application/oda", "oda"),
New HTMLWriter.MimeTypeAssociations("Ogg", "application/ogg", "ogx"),
New HTMLWriter.MimeTypeAssociations("Ogg Audio", "audio/ogg", "oga"),
New HTMLWriter.MimeTypeAssociations("Ogg Video", "video/ogg", "ogv"),
New HTMLWriter.MimeTypeAssociations("OMA Download Agents", "application/vnd.oma.dd2+xml", "dd2"),
New HTMLWriter.MimeTypeAssociations("Open Document Text Web", "application/vnd.oasis.opendocument.text-web", "oth"),
New HTMLWriter.MimeTypeAssociations("Open eBook Publication Structure", "application/oebps-package+xml", "opf"),
New HTMLWriter.MimeTypeAssociations("Open Financial Exchange", "application/vnd.intu.qbo", "qbo"),
New HTMLWriter.MimeTypeAssociations("Open Office Extension", "application/vnd.openofficeorg.extension", "oxt"),
New HTMLWriter.MimeTypeAssociations("Open Score Format", "application/vnd.yamaha.openscoreformat", "osf"),
New HTMLWriter.MimeTypeAssociations("Open Web Media Project - Audio", "audio/webm", "weba"),
New HTMLWriter.MimeTypeAssociations("Open Web Media Project - Video", "video/webm", "webm"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Chart", "application/vnd.oasis.opendocument.chart", "odc"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Chart Template", "application/vnd.oasis.opendocument.chart-template", "otc"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Database", "application/vnd.oasis.opendocument.database", "odb"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Formula", "application/vnd.oasis.opendocument.formula", "odf"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Formula Template", "application/vnd.oasis.opendocument.formula-template", "odft"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Graphics", "application/vnd.oasis.opendocument.graphics", "odg"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Graphics Template", "application/vnd.oasis.opendocument.graphics-template", "otg"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Image", "application/vnd.oasis.opendocument.image", "odi"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Image Template", "application/vnd.oasis.opendocument.image-template", "oti"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Presentation", "application/vnd.oasis.opendocument.presentation", "odp"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Presentation Template", "application/vnd.oasis.opendocument.presentation-template", "otp"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Spreadsheet", "application/vnd.oasis.opendocument.spreadsheet", "ods"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Spreadsheet Template", "application/vnd.oasis.opendocument.spreadsheet-template", "ots"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Text", "application/vnd.oasis.opendocument.text", "odt"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Text Master", "application/vnd.oasis.opendocument.text-master", "odm"),
New HTMLWriter.MimeTypeAssociations("OpenDocument Text Template", "application/vnd.oasis.opendocument.text-template", "ott"),
New HTMLWriter.MimeTypeAssociations("OpenGL Textures (KTX)", "image/ktx", "ktx"),
New HTMLWriter.MimeTypeAssociations("OpenOffice - Calc (Spreadsheet)", "application/vnd.sun.xml.calc", "sxc"),
New HTMLWriter.MimeTypeAssociations("OpenOffice - Calc Template (Spreadsheet)", "application/vnd.sun.xml.calc.template", "stc"),
New HTMLWriter.MimeTypeAssociations("OpenOffice - Draw (Graphics)", "application/vnd.sun.xml.draw", "sxd"),
New HTMLWriter.MimeTypeAssociations("OpenOffice - Draw Template (Graphics)", "application/vnd.sun.xml.draw.template", "std"),
New HTMLWriter.MimeTypeAssociations("OpenOffice - Impress (Presentation)", "application/vnd.sun.xml.impress", "sxi"),
New HTMLWriter.MimeTypeAssociations("OpenOffice - Impress Template (Presentation)", "application/vnd.sun.xml.impress.template", "sti"),
New HTMLWriter.MimeTypeAssociations("OpenOffice - Math (Formula)", "application/vnd.sun.xml.math", "sxm"),
New HTMLWriter.MimeTypeAssociations("OpenOffice - Writer (Text - HTML)", "application/vnd.sun.xml.writer", "sxw"),
New HTMLWriter.MimeTypeAssociations("OpenOffice - Writer (Text - HTML)", "application/vnd.sun.xml.writer.global", "sxg"),
New HTMLWriter.MimeTypeAssociations("OpenOffice - Writer Template (Text - HTML)", "application/vnd.sun.xml.writer.template", "stw"),
New HTMLWriter.MimeTypeAssociations("OpenType Font File", "application/x-font-otf", "otf"),
New HTMLWriter.MimeTypeAssociations("OSFPVG", "application/vnd.yamaha.openscoreformat.osfpvg+xml", "osfpvg"),
New HTMLWriter.MimeTypeAssociations("OSGi Deployment Package", "application/vnd.osgi.dp", "dp"),
New HTMLWriter.MimeTypeAssociations("PalmOS Data", "application/vnd.palm", "pdb"),
New HTMLWriter.MimeTypeAssociations("Pascal Source File", "text/x-pascal", "p"),
New HTMLWriter.MimeTypeAssociations("PawaaFILE", "application/vnd.pawaafile", "paw"),
New HTMLWriter.MimeTypeAssociations("PCL 6 Enhanced (Formely PCL XL)", "application/vnd.hp-pclxl", "pclxl"),
New HTMLWriter.MimeTypeAssociations("Pcsel eFIF File", "application/vnd.picsel", "efif"),
New HTMLWriter.MimeTypeAssociations("PCX Image", "image/x-pcx", "pcx"),
New HTMLWriter.MimeTypeAssociations("Photoshop Document", "image/vnd.adobe.photoshop", "psd"),
New HTMLWriter.MimeTypeAssociations("PICSRules", "application/pics-rules", "prf"),
New HTMLWriter.MimeTypeAssociations("PICT Image", "image/x-pict", "pic"),
New HTMLWriter.MimeTypeAssociations("pIRCh", "application/x-chat", "chat"),
New HTMLWriter.MimeTypeAssociations("PKCS #10 - Certification Request Standard", "application/pkcs10", "p10"),
New HTMLWriter.MimeTypeAssociations("PKCS #12 - Personal Information Exchange Syntax Standard", "application/x-pkcs12", "p12"),
New HTMLWriter.MimeTypeAssociations("PKCS #7 - Cryptographic Message Syntax Standard", "application/pkcs7-mime", "p7m"),
New HTMLWriter.MimeTypeAssociations("PKCS #7 - Cryptographic Message Syntax Standard", "application/pkcs7-signature", "p7s"),
New HTMLWriter.MimeTypeAssociations("PKCS #7 - Cryptographic Message Syntax Standard (Certificate Request Response)", "application/x-pkcs7-certreqresp", "p7r"),
New HTMLWriter.MimeTypeAssociations("PKCS #7 - Cryptographic Message Syntax Standard (Certificates)", "application/x-pkcs7-certificates", "p7b"),
New HTMLWriter.MimeTypeAssociations("PKCS #8 - Private-Key Information Syntax Standard", "application/pkcs8", "p8"),
New HTMLWriter.MimeTypeAssociations("PocketLearn Viewers", "application/vnd.pocketlearn", "plf"),
New HTMLWriter.MimeTypeAssociations("Portable Anymap Image", "image/x-portable-anymap", "pnm"),
New HTMLWriter.MimeTypeAssociations("Portable Bitmap Format", "image/x-portable-bitmap", "pbm"),
New HTMLWriter.MimeTypeAssociations("Portable Compiled Format", "application/x-font-pcf", "pcf"),
New HTMLWriter.MimeTypeAssociations("Portable Font Resource", "application/font-tdpfr", "pfr"),
New HTMLWriter.MimeTypeAssociations("Portable Game Notation (Chess Games)", "application/x-chess-pgn", "pgn"),
New HTMLWriter.MimeTypeAssociations("Portable Graymap Format", "image/x-portable-graymap", "pgm"),
New HTMLWriter.MimeTypeAssociations("Portable Network Graphics (PNG)", "image/png", "png"),
New HTMLWriter.MimeTypeAssociations("Portable Pixmap Format", "image/x-portable-pixmap", "ppm"),
New HTMLWriter.MimeTypeAssociations("Portable Symmetric Key Container", "application/pskc+xml", "pskcxml"),
New HTMLWriter.MimeTypeAssociations("PosML", "application/vnd.ctc-posml", "pml"),
New HTMLWriter.MimeTypeAssociations("PostScript", "application/postscript", "ai"),
New HTMLWriter.MimeTypeAssociations("PostScript Fonts", "application/x-font-type1", "pfa"),
New HTMLWriter.MimeTypeAssociations("PowerBuilder", "application/vnd.powerbuilder6", "pbd"),
New HTMLWriter.MimeTypeAssociations("Pretty Good Privacy", "application/pgp-encrypted", ""),
New HTMLWriter.MimeTypeAssociations("Pretty Good Privacy - Signature", "application/pgp-signature", "pgp"),
New HTMLWriter.MimeTypeAssociations("Preview Systems ZipLock/VBox", "application/vnd.previewsystems.box", "box"),
New HTMLWriter.MimeTypeAssociations("Princeton Video Image", "application/vnd.pvi.ptid1", "ptid"),
New HTMLWriter.MimeTypeAssociations("Pronunciation Lexicon Specification", "application/pls+xml", "pls"),
New HTMLWriter.MimeTypeAssociations("Proprietary P&G Standard Reporting System", "application/vnd.pg.format", "str"),
New HTMLWriter.MimeTypeAssociations("Proprietary P&G Standard Reporting System", "application/vnd.pg.osasli", "ei6"),
New HTMLWriter.MimeTypeAssociations("PRS Lines Tag", "text/prs.lines.tag", "dsc"),
New HTMLWriter.MimeTypeAssociations("PSF Fonts", "application/x-font-linux-psf", "psf"),
New HTMLWriter.MimeTypeAssociations("PubliShare Objects", "application/vnd.publishare-delta-tree", "qps"),
New HTMLWriter.MimeTypeAssociations("Qualcomm's Plaza Mobile Internet", "application/vnd.pmi.widget", "wg"),
New HTMLWriter.MimeTypeAssociations("QuarkXpress", "application/vnd.quark.quarkxpress", "qxd"),
New HTMLWriter.MimeTypeAssociations("QUASS Stream Player", "application/vnd.epson.esf", "esf"),
New HTMLWriter.MimeTypeAssociations("QUASS Stream Player", "application/vnd.epson.msf", "msf"),
New HTMLWriter.MimeTypeAssociations("QUASS Stream Player", "application/vnd.epson.ssf", "ssf"),
New HTMLWriter.MimeTypeAssociations("QuickAnime Player", "application/vnd.epson.quickanime", "qam"),
New HTMLWriter.MimeTypeAssociations("Quicken", "application/vnd.intu.qfx", "qfx"),
New HTMLWriter.MimeTypeAssociations("Quicktime Video", "video/quicktime", "qt"),
New HTMLWriter.MimeTypeAssociations("RAR Archive", "application/x-rar-compressed", "rar"),
New HTMLWriter.MimeTypeAssociations("Real Audio Sound", "audio/x-pn-realaudio", "ram"),
New HTMLWriter.MimeTypeAssociations("Real Audio Sound", "audio/x-pn-realaudio-plugin", "rmp"),
New HTMLWriter.MimeTypeAssociations("Really Simple Discovery", "application/rsd+xml", "rsd"),
New HTMLWriter.MimeTypeAssociations("RealMedia", "application/vnd.rn-realmedia", "rm"),
New HTMLWriter.MimeTypeAssociations("RealVNC", "application/vnd.realvnc.bed", "bed"),
New HTMLWriter.MimeTypeAssociations("Recordare Applications", "application/vnd.recordare.musicxml", "mxl"),
New HTMLWriter.MimeTypeAssociations("Recordare Applications", "application/vnd.recordare.musicxml+xml", "musicxml"),
New HTMLWriter.MimeTypeAssociations("Relax NG Compact Syntax", "application/relax-ng-compact-syntax", "rnc"),
New HTMLWriter.MimeTypeAssociations("RemoteDocs R-Viewer", "application/vnd.data-vision.rdz", "rdz"),
New HTMLWriter.MimeTypeAssociations("Resource Description Framework", "application/rdf+xml", "rdf"),
New HTMLWriter.MimeTypeAssociations("RetroPlatform Player", "application/vnd.cloanto.rp9", "rp9"),
New HTMLWriter.MimeTypeAssociations("RhymBox", "application/vnd.jisp", "jisp"),
New HTMLWriter.MimeTypeAssociations("Rich Text Format", "application/rtf", "rtf"),
New HTMLWriter.MimeTypeAssociations("Rich Text Format (RTF)", "text/richtext", "rtx"),
New HTMLWriter.MimeTypeAssociations("ROUTE 66 Location Based Services", "application/vnd.route66.link66+xml", "link66"),
New HTMLWriter.MimeTypeAssociations("RSS - Really Simple Syndication", "application/rss+xml", "rss"),
New HTMLWriter.MimeTypeAssociations("S Hexdump Format", "application/shf+xml", "shf"),
New HTMLWriter.MimeTypeAssociations("SailingTracker", "application/vnd.sailingtracker.track", "st"),
New HTMLWriter.MimeTypeAssociations("Scalable Vector Graphics (SVG)", "image/svg+xml", "svg"),
New HTMLWriter.MimeTypeAssociations("ScheduleUs", "application/vnd.sus-calendar", "sus"),
New HTMLWriter.MimeTypeAssociations("Search/Retrieve via URL Response Format", "application/sru+xml", "sru"),
New HTMLWriter.MimeTypeAssociations("Secure Electronic Transaction - Payment", "application/set-payment-initiation", "setpay"),
New HTMLWriter.MimeTypeAssociations("Secure Electronic Transaction - Registration", "application/set-registration-initiation", "setreg"),
New HTMLWriter.MimeTypeAssociations("Secured eMail", "application/vnd.sema", "sema"),
New HTMLWriter.MimeTypeAssociations("Secured eMail", "application/vnd.semd", "semd"),
New HTMLWriter.MimeTypeAssociations("Secured eMail", "application/vnd.semf", "semf"),
New HTMLWriter.MimeTypeAssociations("SeeMail", "application/vnd.seemail", "see"),
New HTMLWriter.MimeTypeAssociations("Server Normal Format", "application/x-font-snf", "snf"),
New HTMLWriter.MimeTypeAssociations("Server-Based Certificate Validation Protocol - Validation Policies - Request", "application/scvp-vp-request", "spq"),
New HTMLWriter.MimeTypeAssociations("Server-Based Certificate Validation Protocol - Validation Policies - Response", "application/scvp-vp-response", "spp"),
New HTMLWriter.MimeTypeAssociations("Server-Based Certificate Validation Protocol - Validation Request", "application/scvp-cv-request", "scq"),
New HTMLWriter.MimeTypeAssociations("Server-Based Certificate Validation Protocol - Validation Response", "application/scvp-cv-response", "scs"),
New HTMLWriter.MimeTypeAssociations("Session Description Protocol", "application/sdp", "sdp"),
New HTMLWriter.MimeTypeAssociations("Setext", "text/x-setext", "etx"),
New HTMLWriter.MimeTypeAssociations("SGI Movie", "video/x-sgi-movie", "movie"),
New HTMLWriter.MimeTypeAssociations("Shana Informed Filler", "application/vnd.shana.informed.formdata", "ifm"),
New HTMLWriter.MimeTypeAssociations("Shana Informed Filler", "application/vnd.shana.informed.formtemplate", "itp"),
New HTMLWriter.MimeTypeAssociations("Shana Informed Filler", "application/vnd.shana.informed.interchange", "iif"),
New HTMLWriter.MimeTypeAssociations("Shana Informed Filler", "application/vnd.shana.informed.package", "ipk"),
New HTMLWriter.MimeTypeAssociations("Sharing Transaction Fraud Data", "application/thraud+xml", "tfi"),
New HTMLWriter.MimeTypeAssociations("Shell Archive", "application/x-shar", "shar"),
New HTMLWriter.MimeTypeAssociations("Silicon Graphics RGB Bitmap", "image/x-rgb", "rgb"),
New HTMLWriter.MimeTypeAssociations("SimpleAnimeLite Player", "application/vnd.epson.salt", "slt"),
New HTMLWriter.MimeTypeAssociations("Simply Accounting", "application/vnd.accpac.simply.aso", "aso"),
New HTMLWriter.MimeTypeAssociations("Simply Accounting - Data Import", "application/vnd.accpac.simply.imp", "imp"),
New HTMLWriter.MimeTypeAssociations("SimTech MindMapper", "application/vnd.simtech-mindmapper", "twd"),
New HTMLWriter.MimeTypeAssociations("Sixth Floor Media - CommonSpace", "application/vnd.commonspace", "csp"),
New HTMLWriter.MimeTypeAssociations("SMAF Audio", "application/vnd.yamaha.smaf-audio", "saf"),
New HTMLWriter.MimeTypeAssociations("SMAF File", "application/vnd.smaf", "mmf"),
New HTMLWriter.MimeTypeAssociations("SMAF Phrase", "application/vnd.yamaha.smaf-phrase", "spf"),
New HTMLWriter.MimeTypeAssociations("SMART Technologies Apps", "application/vnd.smart.teacher", "teacher"),
New HTMLWriter.MimeTypeAssociations("SourceView Document", "application/vnd.svd", "svd"),
New HTMLWriter.MimeTypeAssociations("SPARQL - Query", "application/sparql-query", "rq"),
New HTMLWriter.MimeTypeAssociations("SPARQL - Results", "application/sparql-results+xml", "srx"),
New HTMLWriter.MimeTypeAssociations("Speech Recognition Grammar Specification", "application/srgs", "gram"),
New HTMLWriter.MimeTypeAssociations("Speech Recognition Grammar Specification - XML", "application/srgs+xml", "grxml"),
New HTMLWriter.MimeTypeAssociations("Speech Synthesis Markup Language", "application/ssml+xml", "ssml"),
New HTMLWriter.MimeTypeAssociations("SSEYO Koan Play File", "application/vnd.koan", "skp"),
New HTMLWriter.MimeTypeAssociations("Standard Generalized Markup Language (SGML)", "text/sgml", "sgml"),
New HTMLWriter.MimeTypeAssociations("StarOffice - Calc", "application/vnd.stardivision.calc", "sdc"),
New HTMLWriter.MimeTypeAssociations("StarOffice - Draw", "application/vnd.stardivision.draw", "sda"),
New HTMLWriter.MimeTypeAssociations("StarOffice - Impress", "application/vnd.stardivision.impress", "sdd"),
New HTMLWriter.MimeTypeAssociations("StarOffice - Math", "application/vnd.stardivision.math", "smf"),
New HTMLWriter.MimeTypeAssociations("StarOffice - Writer", "application/vnd.stardivision.writer", "sdw"),
New HTMLWriter.MimeTypeAssociations("StarOffice - Writer (Global)", "application/vnd.stardivision.writer-global", "sgl"),
New HTMLWriter.MimeTypeAssociations("StepMania", "application/vnd.stepmania.stepchart", "sm"),
New HTMLWriter.MimeTypeAssociations("Stuffit Archive", "application/x-stuffit", "sit"),
New HTMLWriter.MimeTypeAssociations("Stuffit Archive", "application/x-stuffitx", "sitx"),
New HTMLWriter.MimeTypeAssociations("SudokuMagic", "application/vnd.solent.sdkm+xml", "sdkm"),
New HTMLWriter.MimeTypeAssociations("Sugar Linux Application Bundle", "application/vnd.olpc-sugar", "xo"),
New HTMLWriter.MimeTypeAssociations("Sun Audio - Au file format", "audio/basic", "au"),
New HTMLWriter.MimeTypeAssociations("SundaHus WQ", "application/vnd.wqd", "wqd"),
New HTMLWriter.MimeTypeAssociations("Symbian Install Package", "application/vnd.symbian.install", "sis"),
New HTMLWriter.MimeTypeAssociations("Synchronized Multimedia Integration Language", "application/smil+xml", "smi"),
New HTMLWriter.MimeTypeAssociations("SyncML", "application/vnd.syncml+xml", "xsm"),
New HTMLWriter.MimeTypeAssociations("SyncML - Device Management", "application/vnd.syncml.dm+wbxml", "bdm"),
New HTMLWriter.MimeTypeAssociations("SyncML - Device Management", "application/vnd.syncml.dm+xml", "xdm"),
New HTMLWriter.MimeTypeAssociations("System V Release 4 CPIO Archive", "application/x-sv4cpio", "sv4cpio"),
New HTMLWriter.MimeTypeAssociations("System V Release 4 CPIO Checksum Data", "application/x-sv4crc", "sv4crc"),
New HTMLWriter.MimeTypeAssociations("Systems Biology Markup Language", "application/sbml+xml", "sbml"),
New HTMLWriter.MimeTypeAssociations("Tab Seperated Values", "text/tab-separated-values", "tsv"),
New HTMLWriter.MimeTypeAssociations("Tagged Image File Format", "image/tiff", "tiff"),
New HTMLWriter.MimeTypeAssociations("Tao Intent", "application/vnd.tao.intent-module-archive", "tao"),
New HTMLWriter.MimeTypeAssociations("Tar File (Tape Archive)", "application/x-tar", "tar"),
New HTMLWriter.MimeTypeAssociations("Tcl Script", "application/x-tcl", "tcl"),
New HTMLWriter.MimeTypeAssociations("TeX", "application/x-tex", "tex"),
New HTMLWriter.MimeTypeAssociations("TeX Font Metric", "application/x-tex-tfm", "tfm"),
New HTMLWriter.MimeTypeAssociations("Text Encoding and Interchange", "application/tei+xml", "tei"),
New HTMLWriter.MimeTypeAssociations("Text File", "text/plain", "txt"),
New HTMLWriter.MimeTypeAssociations("TIBCO Spotfire", "application/vnd.spotfire.dxp", "dxp"),
New HTMLWriter.MimeTypeAssociations("TIBCO Spotfire", "application/vnd.spotfire.sfs", "sfs"),
New HTMLWriter.MimeTypeAssociations("Time Stamped Data Envelope", "application/timestamped-data", "tsd"),
New HTMLWriter.MimeTypeAssociations("TRI Systems Config", "application/vnd.trid.tpt", "tpt"),
New HTMLWriter.MimeTypeAssociations("Triscape Map Explorer", "application/vnd.triscape.mxs", "mxs"),
New HTMLWriter.MimeTypeAssociations("troff", "text/troff", "t"),
New HTMLWriter.MimeTypeAssociations("True BASIC", "application/vnd.trueapp", "tra"),
New HTMLWriter.MimeTypeAssociations("TrueType Font", "application/x-font-ttf", "ttf"),
New HTMLWriter.MimeTypeAssociations("Turtle (Terse RDF Triple Language)", "text/turtle", "ttl"),
New HTMLWriter.MimeTypeAssociations("UMAJIN", "application/vnd.umajin", "umj"),
New HTMLWriter.MimeTypeAssociations("Unique Object Markup Language", "application/vnd.uoml+xml", "uoml"),
New HTMLWriter.MimeTypeAssociations("Unity 3d", "application/vnd.unity", "unityweb"),
New HTMLWriter.MimeTypeAssociations("Universal Forms Description Language", "application/vnd.ufdl", "ufd"),
New HTMLWriter.MimeTypeAssociations("URI Resolution Services", "text/uri-list", "uri"),
New HTMLWriter.MimeTypeAssociations("User Interface Quartz - Theme (Symbian)", "application/vnd.uiq.theme", "utz"),
New HTMLWriter.MimeTypeAssociations("Ustar (Uniform Standard Tape Archive)", "application/x-ustar", "ustar"),
New HTMLWriter.MimeTypeAssociations("UUEncode", "text/x-uuencode", "uu"),
New HTMLWriter.MimeTypeAssociations("vCalendar", "text/x-vcalendar", "vcs"),
New HTMLWriter.MimeTypeAssociations("vCard", "text/x-vcard", "vcf"),
New HTMLWriter.MimeTypeAssociations("Video CD", "application/x-cdlink", "vcd"),
New HTMLWriter.MimeTypeAssociations("Viewport+", "application/vnd.vsf", "vsf"),
New HTMLWriter.MimeTypeAssociations("Virtual Reality Modeling Language", "model/vrml", "wrl"),
New HTMLWriter.MimeTypeAssociations("VirtualCatalog", "application/vnd.vcx", "vcx"),
New HTMLWriter.MimeTypeAssociations("Virtue MTS", "model/vnd.mts", "mts"),
New HTMLWriter.MimeTypeAssociations("Virtue VTU", "model/vnd.vtu", "vtu"),
New HTMLWriter.MimeTypeAssociations("Visionary", "application/vnd.visionary", "vis"),
New HTMLWriter.MimeTypeAssociations("Vivo", "video/vnd.vivo", "viv"),
New HTMLWriter.MimeTypeAssociations("Voice Browser Call Control", "application/ccxml+xml,", "ccxml"),
New HTMLWriter.MimeTypeAssociations("VoiceXML", "application/voicexml+xml", "vxml"),
New HTMLWriter.MimeTypeAssociations("WAIS Source", "application/x-wais-source", "src"),
New HTMLWriter.MimeTypeAssociations("WAP Binary XML (WBXML)", "application/vnd.wap.wbxml", "wbxml"),
New HTMLWriter.MimeTypeAssociations("WAP Bitamp (WBMP)", "image/vnd.wap.wbmp", "wbmp"),
New HTMLWriter.MimeTypeAssociations("Waveform Audio File Format (WAV)", "audio/x-wav", "wav"),
New HTMLWriter.MimeTypeAssociations("Web Distributed Authoring and Versioning", "application/davmount+xml", "davmount"),
New HTMLWriter.MimeTypeAssociations("Web Open Font Format", "application/x-font-woff", "woff"),
New HTMLWriter.MimeTypeAssociations("Web Services Policy", "application/wspolicy+xml", "wspolicy"),
New HTMLWriter.MimeTypeAssociations("WebP Image", "image/webp", "webp"),
New HTMLWriter.MimeTypeAssociations("WebTurbo", "application/vnd.webturbo", "wtb"),
New HTMLWriter.MimeTypeAssociations("Widget Packaging and XML Configuration", "application/widget", "wgt"),
New HTMLWriter.MimeTypeAssociations("WinHelp", "application/winhlp", "hlp"),
New HTMLWriter.MimeTypeAssociations("Wireless Markup Language (WML)", "text/vnd.wap.wml", "wml"),
New HTMLWriter.MimeTypeAssociations("Wireless Markup Language Script (WMLScript)", "text/vnd.wap.wmlscript", "wmls"),
New HTMLWriter.MimeTypeAssociations("WMLScript", "application/vnd.wap.wmlscriptc", "wmlsc"),
New HTMLWriter.MimeTypeAssociations("Wordperfect", "application/vnd.wordperfect", "wpd"),
New HTMLWriter.MimeTypeAssociations("Worldtalk", "application/vnd.wt.stf", "stf"),
New HTMLWriter.MimeTypeAssociations("WSDL - Web Services Description Language", "application/wsdl+xml", "wsdl"),
New HTMLWriter.MimeTypeAssociations("X BitMap", "image/x-xbitmap", "xbm"),
New HTMLWriter.MimeTypeAssociations("X PixMap", "image/x-xpixmap", "xpm"),
New HTMLWriter.MimeTypeAssociations("X Window Dump", "image/x-xwindowdump", "xwd"),
New HTMLWriter.MimeTypeAssociations("X.509 Certificate", "application/x-x509-ca-cert", "der"),
New HTMLWriter.MimeTypeAssociations("Xfig", "application/x-xfig", "fig"),
New HTMLWriter.MimeTypeAssociations("XHTML - The Extensible HyperText Markup Language", "application/xhtml+xml", "xhtml"),
New HTMLWriter.MimeTypeAssociations("XML - Extensible Markup Language", "application/xml", "xml"),
New HTMLWriter.MimeTypeAssociations("XML Configuration Access Protocol - XCAP Diff", "application/xcap-diff+xml", "xdf"),
New HTMLWriter.MimeTypeAssociations("XML Encryption Syntax and Processing", "application/xenc+xml", "xenc"),
New HTMLWriter.MimeTypeAssociations("XML Patch Framework", "application/patch-ops-error+xml", "xer"),
New HTMLWriter.MimeTypeAssociations("XML Resource Lists", "application/resource-lists+xml", "rl"),
New HTMLWriter.MimeTypeAssociations("XML Resource Lists", "application/rls-services+xml", "rs"),
New HTMLWriter.MimeTypeAssociations("XML Resource Lists Diff", "application/resource-lists-diff+xml", "rld"),
New HTMLWriter.MimeTypeAssociations("XML Transformations", "application/xslt+xml", "xslt"),
New HTMLWriter.MimeTypeAssociations("XML-Binary Optimized Packaging", "application/xop+xml", "xop"),
New HTMLWriter.MimeTypeAssociations("XPInstall - Mozilla", "application/x-xpinstall", "xpi"),
New HTMLWriter.MimeTypeAssociations("XSPF - XML Shareable Playlist Format", "application/xspf+xml", "xspf"),
New HTMLWriter.MimeTypeAssociations("XUL - XML User Interface Language", "application/vnd.mozilla.xul+xml", "xul"),
New HTMLWriter.MimeTypeAssociations("XYZ File Format", "chemical/x-xyz", "xyz"),
New HTMLWriter.MimeTypeAssociations("YAML Ain't Markup Language / Yet Another Markup Language", "text/yaml", "yaml"),
New HTMLWriter.MimeTypeAssociations("YANG Data Modeling Language", "application/yang", "yang"),
New HTMLWriter.MimeTypeAssociations("YIN (YANG - XML)", "application/yin+xml", "yin"),
New HTMLWriter.MimeTypeAssociations("Z.U.L. Geometry", "application/vnd.zul", "zir"),
New HTMLWriter.MimeTypeAssociations("Zip Archive", "application/zip", "zip"),
New HTMLWriter.MimeTypeAssociations("ZVUE Media Manager", "application/vnd.handheld-entertainment+xml", "zmm"),
New HTMLWriter.MimeTypeAssociations("Zzazz Deck", "application/vnd.zzazz.deck+xml", "zaz")}

  'Private _style = " style=''"
  ''' <summary>
  ''' Searches for reserved words for HTML and replaces the carrots with appropriate meta characters.
  ''' </summary>
  ''' <param name="InputLine">Incoming inner text.</param>
  ''' <returns></returns>
  ''' <remarks></remarks>
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
  Public Function GetMimeTypeAssociationFromFile(ByVal URI As String) As HTMLWriter.MimeTypeAssociations
    If IO.File.Exists(URI) Then
      Dim fi As New IO.FileInfo(URI)
      For Each typ As HTMLWriter.MimeTypeAssociations In MimeTypes
        If String.Equals(fi.Extension, "." & typ.MimeExtension, StringComparison.OrdinalIgnoreCase) Then
          Return typ
        End If
      Next
    End If
    Return Nothing
  End Function
End Module
