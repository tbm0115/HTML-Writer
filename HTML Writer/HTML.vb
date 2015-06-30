Imports System.Drawing

Public Class HTMLWriter
    Private str_html As String
    Public Property HTMLMarkup As String
        Get
            Return str_html
        End Get
        Set(value As String)
            If value.Contains("</html>") Then
                str_html = value
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

    ''' <summary>
    ''' Creates a new instance of an HTML Document
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        str_html = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
    End Sub


    ''' <summary>
    ''' Adds HTML Markup to the current instance of an HTML Document.
    ''' </summary>
    ''' <param name="RawHTML">Adds raw HTML text. Can include raw HTML Markup.</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddToHTMLMarkup(ByVal RawHTML As String)
        If String.IsNullOrEmpty(str_html) Then
            'Set first html tag
            str_html = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
        End If
        str_html = str_html.Replace("</html>", vbTab & RawHTML & vbLf & "</html>")
    End Sub

    ''' <summary>
    ''' Adds HTML Markup to the current instance of an HTML Document.
    ''' </summary>
    ''' <param name="Item">Adds the instance of an HTML Form to the current instance of an HTML Document.</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLForm)
        If String.IsNullOrEmpty(str_html) Then
            'Set first html tag
            str_html = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
        End If
        str_html = str_html.Replace("</html>", vbTab & Item.Form & vbLf & "</html>")
    End Sub

    ''' <summary>
    ''' Adds HTML Markup to the current instance of an HTML Document.
    ''' </summary>
    ''' <param name="Item">Adds the instance of an HTML Header to the current instance of an HTML Document.</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLHeader)
        If String.IsNullOrEmpty(str_html) Then
            'Set first html tag
            str_html = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
        End If
        str_html = str_html.Replace("</html>", vbTab & Item.Header & vbLf & "</html>")
    End Sub

    ''' <summary>
    ''' Adds HTML Markup to the current instance of an HTML Document.
    ''' </summary>
    ''' <param name="Item">Adds the instance of an HTML Table to the current instance of an HTML Document.</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLTable)
        If String.IsNullOrEmpty(str_html) Then
            'Set first html tag
            str_html = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
        End If
        str_html = str_html.Replace("</html>", vbTab & Item.Table & vbLf & "</html>")
    End Sub

    ''' <summary>
    ''' Adds HTML Markup to the current instance of an HTML Document.
    ''' </summary>
    ''' <param name="Item">Adds the instance of an HTML Image Map to the current instance of an HTML Document.</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLImageMap)
        If String.IsNullOrEmpty(str_html) Then
            'Set first html tag
            str_html = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
        End If
        str_html = str_html.Replace("</html>", vbTab & Item.ImageMap & vbLf & "</html>")
    End Sub

    ''' <summary>
    ''' Adds HTML Markup to the current instance of an HTML Document.
    ''' </summary>
    ''' <param name="Item">Adds the instance of an HTML List to the current instance of an HTML Document.</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLList)
        If String.IsNullOrEmpty(str_html) Then
            'Set first html tag
            str_html = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
        End If
        str_html = str_html.Replace("</html>", vbTab & Item.List & vbLf & "</html>")
    End Sub

    ''' <summary>
    ''' Adds HTML Markup to the current instance of an HTML Document.
    ''' </summary>
    ''' <param name="Item">Adds the instance of an HTML List to the current instance of an HTML Document.</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLImage)
        If String.IsNullOrEmpty(str_html) Then
            'Set first html tag
            str_html = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
        End If
        str_html = str_html.Replace("</html>", vbTab & Item.Image & vbLf & "</html>")
    End Sub

    ''' <summary>
    ''' Adds HTML Markup to the current instance of an HTML Document.
    ''' </summary>
    ''' <param name="Item">Adds the instance of an HTML Canvas to the current instance of an HTML Document.</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddToHTMLMarkup(ByVal Item As HTMLCanvas)
        If String.IsNullOrEmpty(str_html) Then
            'Set first html tag
            str_html = "<!DOCTYPE html>" & vbLf & "<html>" & vbLf & "</html>"
        End If
        str_html = str_html.Replace("</html>", vbTab & Item.Canvas & vbLf & "</html>")
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
        Public Property Form As String
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
        ''' <param name="WIDTH">Maximum form width. Accepts CSS markup.</param>
        ''' <param name="SIZE">Text size. Accepts CSS markup.</param>
        ''' <param name="BackColor">Background color of the form. Accepts CSS markup.</param>
        ''' <param name="ALIGN">Text alignment. Accepts CSS markup.</param>
        ''' <remarks></remarks>
        Public Sub New(Optional ByVal Text As String = "", Optional ByVal Attributes As AttributeList = Nothing)
            If Not IsNothing(Attributes) Then
                _form = "<fieldset" & Attributes.GetAttributeString & "><legend>" & ReplaceBadChars(Text) & "</legend></fieldset>" & vbLf
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
                    _form = _form.Replace("</fieldset>" & vbLf, "<span" & LabelAttributes.GetAttributeString & ">" & ReplaceBadChars(Label) & "</span><input" & TextAttributes.GetAttributeString & " disabled='disabled' value=" & chr(34) & ReplaceBadChars(Value) & chr(34) & "/><br/>" & vbLf & "</fieldset>" & vbLf)
                Else
                    _form = _form.Replace("</fieldset>" & vbLf, "<span" & LabelAttributes.GetAttributeString & ">" & ReplaceBadChars(Label) & "</span><input disabled='disabled' value=" & chr(34) & ReplaceBadChars(Value) & chr(34) & "/><br/>" & vbLf & "</fieldset>" & vbLf)
                End If
            Else
                If Not IsNothing(TextAttributes) Then
                    _form = _form.Replace("</fieldset>" & vbLf, "<span>" & ReplaceBadChars(Label) & "</span><input" & TextAttributes.GetAttributeString & " disabled='disabled' value=" & chr(34) & ReplaceBadChars(Value) & chr(34) & "/><br/>" & vbLf & "</fieldset>" & vbLf)
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
        Private _header As String
        Public Property Header As String
            Get
                Return _header
            End Get
            Set(value As String)
                _header = value
            End Set
        End Property

        ''' <summary>
        ''' Creates a new instance of the HTML Header object. 
        ''' This object serves as a Heading or Label in the layout of the HTML Document.
        ''' </summary>
        ''' <param name="TEXT"></param>
        ''' <param name="Attributes"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal TEXT As String, Optional ByVal Attributes As AttributeList = Nothing)
            If Not IsNothing(Attributes) Then
                _header = "<p" & Attributes.GetAttributeString & ">" & ReplaceBadChars(TEXT) & "</p>" & vbLf
            Else
                _header = "<p>" & ReplaceBadChars(TEXT) & "</p>" & vbLf
            End If
        End Sub
    End Class

    ''' <summary>
    ''' Represents an instance of an HTML Table element.
    ''' </summary>
    ''' <remarks></remarks>
    Class HTMLTable
        Private _table As String
        ''' <summary>
        ''' Get/Set the HTML markup for the current instance of an HTML Table directly.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property Table As String
            Get
                Return _table
            End Get
            Set(value As String)
                _table = value
            End Set
        End Property
        ''' <summary>
        ''' Creates a new instance of an HTML Table. A table consists of HTML Table Rows and their columns.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
            If Not IsNothing(Attributes) Then
                _table = "<table" & Attributes.GetAttributeString & ">" & vbLf & "</table>" & vbLf
            Else
                _table = "<table>" & vbLf & "</table>" & vbLf
            End If
        End Sub
        ''' <summary>
        ''' Add the raw HTML Markup consisting of an HTML Table Row.
        ''' </summary>
        ''' <param name="Row">Raw HTML Markup. String.</param>
        ''' <remarks></remarks>
        Public Sub AddTableRow(ByVal Row As String)
            If String.IsNullOrEmpty(_table) Then
                Throw New ApplicationException("Cannot add table row to an undefined table.")
            Else
                If Row.ToUpper.StartsWith("<TH") Then
                    If _table.ToUpper.Contains("<TH") Then
                        _table = _table.Replace(_table.Remove(_table.ToUpper.IndexOf("<TH"), _table.ToUpper.IndexOf("</TH>") + 5), Row)
                    Else
                        _table = _table.Replace(_table.Remove(_table.IndexOf(">") + 1), _table.Remove(_table.IndexOf(">") + 1) & vbLf & vbTab & Row & vbLf)
                    End If
                Else
                    _table = _table.Replace("</table>" & vbLf, vbTab & Row & vbLf & "</table>" & vbLf)
                End If
            End If
        End Sub
        ''' <summary>
        ''' Adds the HTML Markup of an HTML Table Header
        ''' </summary>
        ''' <param name="TableHeader">HTML Table Header Object</param>
        ''' <remarks></remarks>
        Public Sub AddTableRow(ByVal TableHeader As HTMLTableHeader)
            If String.IsNullOrEmpty(_table) Then
                Throw New ApplicationException("Cannot add table row to an undefined table.")
            Else
                If TableHeader.TableHeader.ToUpper.StartsWith("<TH") Then
                    If _table.ToUpper.Contains("<TH") Then
                        _table = _table.Replace(_table.Remove(_table.ToUpper.IndexOf("<TH"), _table.ToUpper.IndexOf("</TH>") + 5), TableHeader.TableHeader)
                    Else
                        _table = _table.Replace(_table.Remove(_table.IndexOf(">") + 1), _table.Remove(_table.IndexOf(">") + 1) & vbLf & vbTab & TableHeader.TableHeader & vbLf)
                    End If
                Else
                    _table = _table.Replace("</table>" & vbLf, vbTab & TableHeader.TableHeader & vbLf & "</table>" & vbLf)
                End If
            End If
        End Sub
        ''' <summary>
        ''' Adds the HTML Markup of an HTML Table Row
        ''' </summary>
        ''' <param name="TableRow">HTML Table Row Object.</param>
        ''' <remarks></remarks>
        Public Sub AddTableRow(ByVal TableRow As HTMLTableRow)
            If String.IsNullOrEmpty(_table) Then
                Throw New ApplicationException("Cannot add table row to an undefined table.")
            Else
                If TableRow.TableRow.ToUpper.Contains("<TH") Then
                    If _table.ToUpper.Contains("<TH") Then
                        _table = _table.Replace(_table.Remove(_table.ToUpper.IndexOf("<TH"), _table.ToUpper.IndexOf("</TH>") + 5), TableRow.TableRow)
                    Else
                        _table = _table.Replace(_table.Remove(_table.IndexOf(">") + 1), _table.Remove(_table.IndexOf(">") + 1) & vbLf & vbTab & TableRow.TableRow & vbLf)
                    End If
                Else
                    _table = _table.Replace("</table>" & vbLf, vbTab & TableRow.TableRow & vbLf & "</table>" & vbLf)
                End If
            End If
        End Sub

        ''' <summary>
        ''' Represents the instance of an HTML Table Header. Serves as a column label.
        ''' </summary>
        ''' <remarks></remarks>
        Class HTMLTableHeader
            Private _th As String
            ''' <summary>
            ''' Get/Set the HTML markup for the current instance of an HTML Table Header directly.
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property TableHeader As String
                Get
                    Return _th
                End Get
                Set(value As String)
                    _th = value
                End Set
            End Property

            ''' <summary>
            ''' Creates a new instance of an HTML Table Header. A table header serves as a label for 
            ''' the proceeding rows and should be added to the HTML Table first.
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
                If Not IsNothing(Attributes) Then
                    _th = "<tr" & Attributes.GetAttributeString & ">" & vbLf & "</tr>" & vbLf
                Else
                    _th = "<tr>" & vbLf & "</tr>" & vbLf
                End If
            End Sub
            ''' <summary>
            ''' Adds a column to the current instance of an HTML Table Header.
            ''' </summary>
            ''' <param name="InnerText">Inner text of the new table cell.</param>
            ''' <remarks></remarks>
            Public Sub AddTableHeaderColumn(ByVal InnerText As String, Optional ByVal Attributes As AttributeList = Nothing)
                If Not _th.Contains(">" & InnerText & "</") Then
                    If Not IsNothing(Attributes) Then
                        _th = _th.Replace("</tr>" & vbLf, vbTab & "<th" & Attributes.GetAttributeString & ">" & ReplaceBadChars(InnerText) & "</th>" & vbLf & "</tr>" & vbLf)
                    Else
                        _th = _th.Replace("</tr>" & vbLf, vbTab & "<th>" & ReplaceBadChars(InnerText) & "</th>" & vbLf & "</tr>" & vbLf)
                    End If
                Else
                    Throw New ApplicationException("{HTML}HTMLTableHeader: Cannot add a duplicate table header. Attempted header=" & chr(34) & InnerText & chr(34) & "")
                End If
            End Sub
        End Class
        ''' <summary>
        ''' Represents the instance of an HTML Table Row.
        ''' </summary>
        ''' <remarks></remarks>
        Class HTMLTableRow
            Private _tr, _style As String
            ''' <summary>
            ''' Get/Set the HTML markup for the current instance of an HTML Table Row directly.
            ''' </summary>
            ''' <value></value>
            ''' <returns></returns>
            ''' <remarks></remarks>
            Public Property TableRow As String
                Get
                    Return _tr
                End Get
                Set(value As String)
                    _tr = value
                End Set
            End Property

            ''' <summary>
            ''' Creates a new instance of an HTML Table Row. A table row helps provide substance to the content of the table.
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub New(Optional ByVal Attributes As AttributeList = Nothing)
                If Not IsNothing(Attributes) Then
                    _tr = "<tr " & Attributes.GetAttributeString & ">" & vbLf & "</tr>" & vbLf
                Else
                    _tr = "<tr>" & vbLf & "</tr>" & vbLf
                End If
            End Sub
            ''' <summary>
            ''' Adds a column to the current instance of an HTML Table Row.
            ''' </summary>
            ''' <param name="InnerText">Inner text of the new table cell.</param>
            ''' <remarks></remarks>
            Public Sub AddTableColumn(ByVal InnerText As String, Optional ByVal Attributes As AttributeList = Nothing)
                If Not IsNothing(Attributes) Then
                    _tr = _tr.Replace("</tr>" & vbLf, vbTab & "<td" & Attributes.GetAttributeString & ">" & ReplaceBadChars(InnerText) & "</td>" & vbLf & "</tr>" & vbLf)
                Else
                    _tr = _tr.Replace("</tr>" & vbLf, vbTab & "<td>" & ReplaceBadChars(InnerText) & "</td>" & vbLf & "</tr>" & vbLf)
                End If
            End Sub
        End Class
    End Class

    ''' <summary>
    ''' Represents an instance of an HTML Image with an HTML Image Map
    ''' </summary>
    ''' <remarks></remarks>
    Class HTMLImageMap
        Private _img As String
        Private _width As Integer
        Private _height As Integer
        Private _map As String
        Private _imgmap As String
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
        ReadOnly Property ImageMap As String
            Get
                Return _imgmap
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
                Return _map
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
                Return _img
            End Get
            Set(value As String)
                _img = value
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

        ''' <summary>
        ''' Adds a new instance of an HTML Map Area to the Map element of the current instance of an HTML Image Map.
        ''' </summary>
        ''' <param name="Area">HTML Map Area object.</param>
        ''' <param name="MapName">Only applies to first addition of an HTML Map Area, this sets the name of the HTML Image Map.
        ''' This name is used when applying coordinates to an HTML Image element.</param>
        ''' <remarks></remarks>
        Public Overloads Sub AddMapArea(ByVal Area As HTMLMapArea, Optional ByVal MapName As String = "map0")
            If String.IsNullOrEmpty(_map) Then
                _map = "<map name=" & Chr(34) & MapName & Chr(34) & ">" & vbLf & vbTab & Area.MapArea & vbLf & "</map>" & vbLf
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
            If String.IsNullOrEmpty(_map) Then
                _map = "<map name=" & Chr(34) & MapName & Chr(34) & ">" & vbLf & vbTab & Area & vbLf & "</map>" & vbLf
            Else
                _map = _map.Replace("</map>" & vbLf, vbTab & Area & vbLf & "</map>" & vbLf)
            End If
        End Sub

        ''' <summary>
        ''' Creates a new instance of an HTML Image Map, so long as all properties have been set.
        ''' </summary>
        ''' <remarks></remarks>
        Public Overloads Sub CreateImageMap()
            If IsNothing(_width) = True Or IsNothing(_height) = True Or IsNothing(_img) = True Or IsNothing(_map) = True Then
                Throw New ApplicationException("{HTML}CreateImageMap: HTMLImageMap must of have all properties set. {ImageUrl,ImageWidth,ImageHeight,Map}")
            Else
                _imgmap = "<img width=" & Chr(34) & _width.ToString & Chr(34) & " height=" & Chr(34) & _height.ToString & Chr(34) & " src=" & Chr(34) & _img & Chr(34) & " usemap=" & Chr(34) & _map & Chr(34) & "/>" & vbLf
            End If
        End Sub
        ''' <summary>
        ''' Creates a new instance of an HTML Image Map.
        ''' </summary>
        ''' <param name="Width">Width of the HTML Image element.</param>
        ''' <param name="Height">Height of the HTML Image element.</param>
        ''' <param name="ImageUrl">Location of the image. HTTP, File, etc.</param>
        ''' <param name="Map"></param>
        ''' <remarks></remarks>
        Public Overloads Sub CreateImageMap(ByVal Width As Integer, ByVal Height As Integer, ByVal ImageUrl As String, ByVal Map As String)
            _width = Width
            _height = Height
            _img = ImageUrl
            _map = Map
            If IsNothing(_width) = True Or IsNothing(_height) = True Or IsNothing(_img) = True Or IsNothing(_map) = True Then
                Throw New ApplicationException("{HTML}CreateImageMap: HTMLImageMap must of have all properties set. {ImageUrl,ImageWidth,ImageHeight,Map}")
            Else
                _imgmap = "<img width=" & Chr(34) & _width.ToString & Chr(34) & " height=" & Chr(34) & _height.ToString & Chr(34) & " src=" & Chr(34) & _img & Chr(34) & " usemap=" & Chr(34) & _map & Chr(34) & "/>" & vbLf
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
                    _AREA += "shape=" & chr(34) & _shape & chr(34) & " "
                Else
                    Throw New ApplicationException("{HTML}CreateMapArea: HTMLMapArea ShapeType must be set before attempting to CreateMapArea().")
                End If
                If Not String.IsNullOrEmpty(_coords) Then
                    _AREA += "coords=" & chr(34) & _coords & chr(34) & " "
                Else
                    Throw New ApplicationException("{HTML}CreateMapArea: HTMLMapArea Coordinates must be set before attempting to CreateMapArea().")
                End If
                If Not String.IsNullOrEmpty(_target) Then
                    _AREA += "target=" & chr(34) & _target & chr(34) & " "
                End If
                If Not String.IsNullOrEmpty(_href) Then
                    _AREA += "href=" & chr(34) & _href & chr(34) & " "
                End If
                If Not String.IsNullOrEmpty(_clickevent) Then
                    _AREA += "onClick=" & chr(34) & _clickevent & chr(34) & " "
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
    End Class

    ''' <summary>
    ''' Represents an instance of an HTML List. Consists of either bulleted or numbered lists.
    ''' </summary>
    ''' <remarks></remarks>
    Class HTMLList
        Private _list As String
        Private _CssClass As String
        Private _ltype As ListType

        ''' <summary>
        ''' Get/Set the optional CSS Class name associated with the list(s)
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property CssClassName As String
            Get
                Return _CssClass
            End Get
            Set(value As String)
                _CssClass = value
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
        ''' <summary>
        ''' Get the raw HTML markup for the current instance of an HTML List.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property List As String
            Get
                Return _list
            End Get
        End Property

        ''' <summary>
        ''' Get the total number of list items found (even child items) in the raw HTML markup provided. Searches by provided
        '''  List Type.
        ''' </summary>
        ''' <param name="ListString">Raw HTML markup.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function CountItems(ByVal ListString As String) As Integer
            Dim strTemp As String = ListString
            Dim cnt As Integer = 0
            Do Until strTemp.Contains("</" & GetListTypeTag(_ltype) & ">") = False
                If strTemp.Contains("</" & GetListTypeTag(_ltype) & ">") Then
                    strTemp = strTemp.Remove(0, strTemp.IndexOf("</" & GetListTypeTag(_ltype) & ">") + 5)
                    cnt += 1
                End If
            Loop
            Return cnt
        End Function
        ''' <summary>
        ''' Get the total number of list items found (even child items) in the raw HTML markup provided. Searches by provided
        '''  List Type.
        ''' </summary>
        ''' <param name="ListString">Raw HTML markup.</param>
        ''' <param name="ListType">Specified List Type.</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Overloads Function CountItems(ByVal ListString As String, ByVal ListType As ListType) As Integer
            Dim strTemp As String = ListString
            Dim cnt As Integer = 0
            Do Until strTemp.Contains("</" & GetListTypeTag(ListType) & ">") = False
                If strTemp.Contains("</" & GetListTypeTag(ListType) & ">") Then
                    strTemp = strTemp.Remove(0, strTemp.IndexOf("</" & GetListTypeTag(ListType) & ">") + 5)
                    cnt += 1
                End If
            Loop
            Return cnt
        End Function
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
        Private Sub ReplaceCssClass()
            Try
                'Check if the ListString should be updated to add the CssClass
                If Not String.IsNullOrEmpty(_list) Then
                    'Verify ListType has been set for this instance of the object
                    If Not IsNothing(_ltype) Then
                        'Check if the ListString has a CssClass already
                        If _list.StartsWith("<" & GetListTypeTag(_ltype) & " CssClass") Then
                            '<?l CssClass="example">    ->  <?l CssClass=example">
                            _list = _list.Remove(_list.IndexOf("Class") + 9, _list.IndexOf(Chr(34)) + 1)
                            '<?l CssClassexample">      ->  <?l CssClass=>
                            _list = _list.Remove(_list.IndexOf("Class") + 9, _list.IndexOf(Chr(34)) + 1)
                            '<?l CssClass=>             ->  <?l CssClass="new">
                            _list = _list.Insert(_list.IndexOf("Class") + 9, Chr(34) & _CssClass & Chr(34))
                        Else
                            _list = "<" & GetListTypeTag(_ltype) & " CssClass=" & Chr(34) & _CssClass & Chr(34) & ">" & vbLf
                        End If
                    Else
                        Throw New ApplicationException("{HTML}HTMLList: CssClassName cannot be set after ListItems have been added without a value for ListType set to the object.")
                    End If
                End If
            Catch ex As Exception
                Throw New ApplicationException("{HTML}ReplaceCssClass: Catch=" & ex.Message)
            End Try
        End Sub
        Private Function InsertCssClass(Optional ByVal CssClass = Nothing) As String
            If Not String.IsNullOrEmpty(CssClass) Then
                Return " CssClass=" & Chr(34) & CssClass & Chr(34)
            ElseIf Not String.IsNullOrEmpty(_CssClass) Then
                Return " CssClass=" & Chr(34) & _CssClass & Chr(34)
            Else
                Return ""
            End If
        End Function

        ''' <summary>
        ''' Appends a new value to the current instance of an HTML List using the current List Type.
        ''' </summary>
        ''' <param name="Value">Inner text</param>
        ''' <param name="CssClass">Optional CSS Class name for the specific List Item</param>
        ''' <remarks></remarks>
        Public Overloads Sub AddItem(ByVal Value As String, Optional ByVal CssClass As String = Nothing)
            If String.IsNullOrEmpty(_list) Then
                'Add first item
                _list = "<" & GetListTypeTag(_ltype) & InsertCssClass() & ">" & vbLf & vbTab & "<li" & InsertCssClass(CssClass) & ">" & ReplaceBadChars(Value) & "</li>" & vbLf & "</" & GetListTypeTag(_ltype) & ">" & vbLf
            Else
                'Add subsequent item
                _list = _list.Replace("</" & GetListTypeTag(_ltype) & ">" & vbLf, vbTab & "<li" & InsertCssClass(CssClass) & ">" & ReplaceBadChars(Value) & "</li>" & vbLf & "</" & GetListTypeTag(_ltype) & ">" & vbLf)
            End If
        End Sub
        ''' <summary>
        ''' Appends a new value to the current instance of an HTML List.
        ''' </summary>
        ''' <param name="Value">Inner text</param>
        ''' <param name="ListType">Specifies the List Item Type</param>
        ''' <param name="CssClass">Optional CSS Class name for the specific List Item</param>
        ''' <remarks></remarks>
        Public Overloads Sub AddItem(ByVal Value As String, ByVal ListType As ListType, Optional ByVal CssClass As String = Nothing)
            If String.IsNullOrEmpty(_list) Then
                'Add first item
                _list = "<" & GetListTypeTag(ListType) & InsertCssClass() & ">" & vbLf & vbTab & "<li" & InsertCssClass(CssClass) & ">" & ReplaceBadChars(Value) & "</li>" & vbLf & "</" & GetListTypeTag(ListType) & ">" & vbLf
            Else
                'Add subsequent item
                _list = _list.Replace("</" & GetListTypeTag(ListType) & ">" & vbLf, vbTab & "<li" & InsertCssClass(CssClass) & ">" & ReplaceBadChars(Value) & "</li>" & vbLf & "</" & GetListTypeTag(ListType) & ">" & vbLf)
            End If
        End Sub
        ''' <summary>
        ''' Appends a new List Item to the current instance of an HTML List.
        ''' </summary>
        ''' <param name="ListString">Raw HTML markup.</param>
        ''' <remarks></remarks>
        Public Overloads Sub AddList(ByVal ListString As String)
            If String.IsNullOrEmpty(_list) Then
                'Add first item
                _list = "<" & GetListTypeTag(_ltype) & ">" & vbLf & vbTab & ReplaceBadChars(ListString) & vbLf & "</" & GetListTypeTag(_ltype) & ">" & vbLf
            Else
                'Add subsequent list
                _list = _list.Replace("</" & GetListTypeTag(_ltype) & ">", "<" & GetListTypeTag(_ltype) + ">" & vbLf & vbTab & ReplaceBadChars(ListString) & vbLf & "</" & GetListTypeTag(_ltype) & ">" & vbLf)
            End If
        End Sub
        ''' <summary>
        ''' Appends a new List Item to the current instance of an HTML List.
        ''' </summary>
        ''' <param name="ListString">Raw HTML markup.</param>
        ''' <param name="ListType">Specifies the List Item Type</param>
        ''' <remarks></remarks>
        Public Overloads Sub AddList(ByVal ListString As String, ByVal ListType As ListType)
            If String.IsNullOrEmpty(_list) Then
                'Add first item
                _list = "<" & GetListTypeTag(ListType) & ">" & vbLf & vbTab & ReplaceBadChars(ListString) & vbLf & "</" & GetListTypeTag(ListType) & ">" & vbLf
            Else
                'Add subsequent list
                _list = _list.Replace("</" & GetListTypeTag(ListType) & ">", "<" & GetListTypeTag(ListType) & ">" & vbLf & vbTab & ReplaceBadChars(ListString) & vbLf & "</" & GetListTypeTag(ListType) & ">" & vbLf)
            End If
        End Sub
    End Class

    ''' <summary>
    ''' Represents an instance of an HTML Image.
    ''' </summary>
    ''' <remarks></remarks>
    Class HTMLImage
        Private _img As String

        Public ReadOnly Property Image As String
            Get
                Return _img
            End Get
        End Property

        ''' <summary>
        ''' Creates a new instance of the HTML Header object. 
        ''' This object serves as a Heading or Label in the layout of the HTML Document.
        ''' </summary>
        ''' <param name="Source"></param>
        ''' <param name="Attributes"></param>
        ''' <remarks></remarks>
        Public Sub New(ByVal Source As String, Optional ByVal Attributes As AttributeList = Nothing)
            If Not IsNothing(Attributes) Then
                _img = "<img src=" & Chr(34) & Source & Chr(34) & " " & Attributes.GetAttributeString & "/>" & vbLf
            Else
                _img = "<img src=" & Chr(34) & Source & Chr(34) & "/>" & vbLf
            End If
        End Sub
    End Class

    Class HTMLCanvas
        Private _cnv As String

        Public ReadOnly Property Canvas As String
            Get
                Return _cnv
            End Get
        End Property

        Public Sub New(ByVal Name As String, Optional ByVal Attributes As AttributeList = Nothing)
            If Not IsNothing(Attributes) Then
                _cnv = "<canvas id=" & Chr(34) & Name & Chr(34) & " " & Attributes.GetAttributeString & ">This browser does not appear to support the HTML Canvas tag...</canvas>" & vbLf
            Else
                _cnv = "<canvas id=" & Chr(34) & Name & Chr(34) & ">This browser does not appear to support the HTML Canvas tag...</canvas>" & vbLf
            End If
        End Sub
    End Class
End Class
Public Class AttributeList
    Private _attr(), _style As String

    ''' <summary>
    ''' Returns the full list of attributes
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Attributes As String()
        Get
            Return _attr
        End Get
        Set(value As String())
            _attr = value
        End Set
    End Property
    ''' <summary>
    ''' Returns the number of HTML element attributes in the current instance of an AttributeList
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AttributeCount As Integer
        Get
            Return _attr.Length
        End Get
    End Property

    ''' <summary>
    ''' Initializes a new instance of an AttributeList
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        _style = "style=" & Chr(34) & Chr(34)
        _attr = Nothing
    End Sub
    Public Sub New(ByVal AttributeNames() As String, ByVal AttributeValues() As String, Optional ByVal IsAllStyle As Boolean = False)
        _style = "style=" & Chr(34) & Chr(34)
        _attr = Nothing
        If Not IsNothing(AttributeNames) Then
            If Not IsNothing(AttributeValues) Then
                If AttributeNames.Length = AttributeValues.Length Then
                    For i = 0 To AttributeNames.Length - 1 Step 1
                        AddAttribute(AttributeNames(i), AttributeValues(i), IsAllStyle)
                    Next
                Else
                    Throw New ApplicationException("Attribute arrays must be the same size!")
                End If
            Else
                Throw New ApplicationException("Attribute Values array cannot be null or empty!`")
            End If
        Else
            Throw New ApplicationException("Attribute array cannot be null or empty!")
        End If
    End Sub
    ''' <summary>
    ''' Returns the full HTML attribute string at the specified index of the current instance of an AttributeList
    ''' </summary>
    ''' <param name="Index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetAttributeAt(ByVal Index As Integer) As String
        If Not IsNothing(_attr) Then
            If Not _attr.Length - 1 < Index Then
                Return _attr(Index)
            Else
                Throw New ApplicationException("Index outside bounds of the array.")
            End If
        Else
            Throw New ApplicationException("Object is empty.")
        End If
    End Function
    ''' <summary>
    ''' Returns the full HTML attribute string at the specified instance of an AttributeName. If the AttributeName does not exist
    ''' in the current instance of an AttributeList, then the function returns nothing.
    ''' </summary>
    ''' <param name="AttributeName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function GetAttributeAt(ByVal AttributeName As String) As String
        If Not IsNothing(_attr) Then
            For i = 0 To _attr.Length - 1 Step 1
                If _attr(i).StartsWith(AttributeName) Then
                    Return _attr(i)
                End If
            Next
        Else
            Throw New ApplicationException("Object is empty.")
        End If
        Return Nothing
    End Function
    ''' <summary>
    ''' Adds a HTML element attribute (or CSS style attribute) to the current instance of an AttributeList
    ''' </summary>
    ''' <param name="AttributeName">Name of the HTML element attribute. ie; OnClick, Width, CssClass, etc.</param>
    ''' <param name="AttributeValue">Value of the HTML element attribute. ie; someJavaFunction();, 100px, someCssClass.</param>
    ''' <param name="IsStyle">If enabled, instead adds the specified attribute name/value to the static Style attribute 
    ''' for the current instance of an AttributeList</param>
    ''' <remarks></remarks>
    Public Overloads Sub AddAttribute(ByVal AttributeName As String, ByVal AttributeValue As String, Optional ByVal IsStyle As Boolean = False)
        Dim cnt As Integer
        If Not IsNothing(_attr) Then
            cnt = _attr.Length
        Else
            cnt = 0
        End If
        If Not IsStyle Then
            If Not String.IsNullOrEmpty(AttributeValue) Then
                ReDim Preserve _attr(cnt)
                _attr(cnt) = AttributeName & "=" & Chr(34) & AttributeValue & Chr(34)
            Else
                Throw New ApplicationException("Attribute Value cannot be null or empty!")
            End If
        Else
            If Not String.IsNullOrEmpty(AttributeValue) Then
                If String.IsNullOrEmpty(_style) Then
                    _style = "style=" & Chr(34) & Chr(34)
                End If
                _style = _style.Replace("=" & Chr(34), "=" & Chr(34) & AttributeName & ": " & AttributeValue & ";")
            Else
                Throw New ApplicationException("Attribute Value cannot be null or empty!")
            End If
        End If
    End Sub
    ''' <summary>
    ''' Adds a series of HTML element attributes to the current instance of an AttributeList
    ''' </summary>
    ''' <param name="AttributeNames"></param>
    ''' <param name="AttributeValues"></param>
    ''' <remarks></remarks>
    Public Overloads Sub AddAttribute(ByVal AttributeNames() As String, ByVal AttributeValues() As String)
        Dim cnt As Integer
        If Not IsNothing(_attr) Then
            cnt = _attr.Length
        Else
            cnt = 0
        End If
        If IsNothing(AttributeNames) Then
            Throw New ApplicationException("Attribute Names array cannot be null or empty!")
        End If
        If IsNothing(AttributeValues) Then
            Throw New ApplicationException("Attribute Values array cannot be null or empty!")
        End If
        If Not AttributeNames.Length = AttributeValues.Length Then
            Throw New ApplicationException("Attribute Names and Attribute Values arrays cannot be different sizes!")
        End If
        For i = 0 To AttributeNames.Length - 1 Step 1
            cnt += 1
            ReDim Preserve _attr(cnt)
            _attr(cnt) = AttributeNames(i) & "=" & Chr(34) & AttributeValues(i) & Chr(34)
        Next
    End Sub

    ''' <summary>
    ''' Get the properly formatted series of HTML attributes in the current instance of an AttributeList
    ''' </summary>
    ''' <returns>String</returns>
    ''' <remarks></remarks>
    Public Function GetAttributeString() As String
        Dim out As String = ""
        If Not IsNothing(_attr) Then
            For Each attr As String In _attr
                out += " " & attr
            Next
        End If
        If Not IsNothing(_style) Then
            out += " " & _style
        End If
        Return out
    End Function

    ''' <summary>
    ''' Removes the HTML element attribute at the specified index
    ''' </summary>
    ''' <param name="Index">Zero-based index to remove object from array.</param>
    ''' <remarks></remarks>
    Public Overloads Sub RemoveAttributeAt(ByVal Index As Integer)
        If Not IsNothing(_attr) Then
            If Not _attr.Length - 1 < Index Then
                Dim tmp() As String
                For i = 0 To _attr.Length - 1 Step 1
                    If Not i = Index Then
                        If Not IsNothing(tmp) Then
                            ReDim Preserve tmp(tmp.Length)
                        Else
                            ReDim tmp(0)
                        End If
                        tmp(tmp.Length - 1) = _attr(i)
                    End If
                Next
                _attr = tmp
            Else
                Throw New ApplicationException("Index outside bounds of the array.")
            End If
        Else
            Throw New ApplicationException("Object is empty.")
        End If
    End Sub
    ''' <summary>
    ''' Removes the HTML element attribute at all instances of the specified Attribute Name
    ''' </summary>
    ''' <param name="AttributeName">Name of the HTML element attribute. ie; OnClick, Width, CssClass, etc.</param>
    ''' <remarks></remarks>
    Public Overloads Sub RemoveAttributeAt(ByVal AttributeName As String)
        If Not IsNothing(_attr) Then
            Dim tmp() As String
            For i = 0 To _attr.Length - 1 Step 1
                If Not _attr(i).StartsWith(AttributeName) Then
                    If Not IsNothing(tmp) Then
                        ReDim Preserve tmp(tmp.Length)
                    Else
                        ReDim tmp(0)
                    End If
                    tmp(tmp.Length - 1) = _attr(i)
                End If
            Next
            _attr = tmp
        Else
            Throw New ApplicationException("Object is empty.")
        End If
    End Sub

End Class
Public Module SharedFunctions
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
                                   "head", "title", "base", "link", "meta", "style"}
    Private _style = " style=''"
    ''' <summary>
    ''' Searches for reserved words for HTML and replaces the carrots with appropriate meta characters.
    ''' </summary>
    ''' <param name="InputLine">Incoming inner text.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReplaceBadChars(ByVal InputLine As String) As String
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
                                If Flags(n).StartsWith("<" & tag & " ") Or Flags(n).StartsWith("<" & tag & ">") Then
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
        Return InputLine
    End Function
    ''' <summary>
    ''' Returns a reformatted HTML element innertext with specified anchor (<a></a>) tags. Specify HREF and Id in AttributeList
    ''' </summary>
    ''' <param name="Attributes">Used to specify values for HREF, ID, TARGET, etc.</param>
    ''' <param name="InputText">Original Inner Text</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IncludeAnchor(ByVal Attributes As AttributeList, ByVal InputText As String) As String
        Return "<a" & Attributes.GetAttributeString & ">" & InputText '& "</a>"
    End Function

End Module
