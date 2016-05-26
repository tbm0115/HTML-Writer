
# HTML-Writer
A .NET 2.0 library for generating HTML markup.

The purpose of this library is to provide a clean alternative to "hard-coded" strings of HTML markup in .NET applications. Ideally, 
new classes will be added to the solution to allow the creation of more HTML5 and CSS3 (or whatever comes next).

#Background
This library was created for use within a small machine shop. Custom applications required simple reporting features and writing 
HTML5 markup in string variables "muddy"ed up the code. So, the solution was to hide it and robust the code in a class.

The library started within .NET 3.5 framework, but hardware requirements within the shop forced a change to .NET 2.0.


#Available HTML tags
<ul>
  <li>"Form" (basically a fieldset with addition of labels and textboxes) {DEPRECATED}</li>
  <li>Header <span class="markup">&lt;h#&gt;</span></li>
  <li>Paragraph <span class="markup">&lt;p&gt;</span></li>
  <li>Table <span class="markup">&lt;table&gt;, &lt;thead&gt;, &lt;tbody&gt;</span>
    <ul>
      <li>Table Header {REMOVED}</li>
      <li>Table Row <span class="markup">&lt;tr&gt;</span>
        <ul>
          <li>Table Cell <span class="markup">&lt;th&gt;, &lt;td&gt;</span></li>
        </ul>
      </li>
    </ul>
  </li>
  <li>Image Map <span class="markup">&lt;img&gt;</span>
    <ul>
      <li>Map Area <span class="markup">&lt;area&gt;</span></li>
    </ul>
  </li>
  <li>List (with Types) <span class="markup">&lt;ul&gt;, &lt;ol&gt;</span>
    <ul>
      <li>List Item <span class="markup">&lt;li&gt;</span></li>
    </ul>
  </li>
  <li>Image <span class="markup">&lt;img&gt;</span></li>
  <li>Canvas <span class="markup">&lt;canvas&gt;</span></li>
  <li>Anchor <span class="markup">&lt;a&gt;</span></li>
  <li>Input <span class="markup">&lt;input&gt;</span></li>
  <li>Label <span class="markup">&lt;label&gt;</span></li>
  <li>Select <span class="markup">&lt;select&gt;, &lt;option&gt;</span></li>
  <li>Progress <span class="markup">&lt;progress&gt;</span></li>
  <li>Meter <span class="markup">&lt;meter&gt;</span></li>
  <li>Video <span class="markup">&lt;video&gt;</span></li>
  <li>Audio <span class="markup">&lt;audio&gt;</span></li>
	<li>Div <span class="markup">&lt;div&gt;</span></li>
	<li>Span <span class="markup">&lt;span&gt;</span></li>
</ul>

#Usage
Import the HTML library to your project and <pre><code>Imports HTML.HTMLWriter</code></pre> to get started.

Start with an <pre><code>HTMLWriter</code></pre> object and work from there.

Example:
Write a simple table
```vb
Imports HTML, HTMLWriter

Public Class Form1
  Public Sub GenerateHTMLReport(ByVal FilePath As String)
    Dim Report As New HTMLWriter

    'Begin writing report data to HTML Table
    Dim Table As New HTMLTable
    'Add Attribute Style to table header with the provided CSS
    Dim TH As New HTMLTable.HTMLTableRow(New AttributeList({"background-color"}, {"lightblue"}, True))
    TH.AddTableCell(New HTMLTableCell("Column 1", HTMLTableCell.CellType.Header))
    TH.AddTableCell(New HTMLTableCell("Column 2", HTMLTableCell.CellType.Header))
    TH.AddTableCell(New HTMLTableCell("Column 3", HTMLTableCell.CellType.Header))
    TH.AddTableCell(New HTMLTableCell("Column 4", HTMLTableCell.CellType.Header))
    TH.AddTableCell(New HTMLTableCell("Column 5", HTMLTableCell.CellType.Header))
    Table.AddTableRow(TH)
    Dim TR As HTMLTable.HTMLTableRow

    For i = 0 To 10 Step 1
      TR = New HTMLTable.HTMLTableRow()
      For j = 0 To 5 Step 1
        TR += New HTMLTableCell(j.ToString, HTMLTableCell.CellType.Row)
      Next
      Debug.WriteLine(vbTab & "Added '" & TR.Count.ToString & "' cells to the row...")
      Table += TR
    Next
    Debug.WriteLine("Added '" & Table.Count.ToString & "' rows to the table...")
    'Add HTML objects to "Report"
    Report += New HTMLHeader("Hello World")
    Report += Table
    'Write all HTML markup to specified file (passed in sub)
    File.WriteAllText(FilePath, Report.HTMLMarkup)
  End Sub
End Class
```


#Attributes
HTML tag attributes are handled a bit more dynamically. Attributes can be applied to almost every tag object in this library using the AttributeList object. This object utilizes string arrays to create either Attribute Items or Style Items (depending on the type of attribute).

Here's an example of the AttributeList at work. Take the for loop in the example above into consideration, we're going to add some styling and attribtes to the controls:
```vb
For i = 0 To 10 Step 1
  '' Alternate the row styling with each row
  If i and 1 Then
    TR = New HTMLTable.HTMLTableRow(New AttributeList({"background-color","color"},{"#222","whitesmoke"},True))
  Else
    TR = New HTMLTable.HTMLTableRow(New AttributeList({"background-color","color"},{"whitesmoke","#222"},True))
  End If
  For j = 0 To 5 Step 1
    '' We'll add DataSet attributes to each cell in case we want to use some JavaScript/JQuery later.
    ''By default, string arrays applied to a new AttributeList will be assumed common attributes and not styling attributes.
    TR += New HTMLTableCell(i.ToString & "-" & j.ToString(), HTMLTableCell.CellType.Row, New AttributeList({"data-row", "data-col"},{i.ToString(), j.ToString()}))
  Next
  Debug.WriteLine(vbTab & "Added '" & TR.Count.ToString & "' cells to the row...")
  Table += TR
Next
```
