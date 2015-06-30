# HTML-Writer
A .NET 2.0 library for generating HTML markup.

The purpose of this library is to provide a clean alternative to "hard-coded" strings of HTML markup in .NET applications. Ideally, 
new classes will be added to the solution to allow the creation of more HTML5 and CSS3 (or whatever comes next).

#Background
This library was created for use within a small machine shop. Custom applications required simple reporting features and writing 
HTML5 markup in string variables "muddy"ed up the code. So, the solution was to hide it and robust the code in a class.

The library started within .NET 3.5 framework, but hardware requirements within the shop forced a change to .NET 2.0.


#Available HTML
<ul>
  <li>"Form" (basically a fieldset with addition of text labels and textboxes)</li>
  <li>Header</li>
  <li>Table
    <ul>
      <li>Table Header</li>
      <li>Table Row</li>
    </ul>
  </li>
  <li>Image Map
    <ul>
      <li>Area</li>
    </ul>
  </li>
  <li>List
    <ul>
      <li>Ordered List</li>
      <li>Unordered List</li>
    </ul>
  </li>
  <li>Image</li>
  <li>Canvas</li>
</ul>

#Usage
Import the HTML library to your project and <pre><code>Imports HTML, HTML.HTMLWriter</code></pre> to get started.

Start with an <pre><code>HTMLWriter</code></pre> object and work from there.

Example:
Write a simple table
<pre>
<code>
Imports HTML, HTMLWriter

Public Class Form1
  Public Sub GenerateHTMLReport(ByVal FilePath As String)
        Dim Report As New HTMLWriter
        Dim Header As New HTMLHeader("Hello World")
        'Begin writing report data to HTML Table
        Dim Table As New HTMLTable
        'Add Attribute Style to table header with the provided CSS
        Dim TH As New HTMLTable.HTMLTableHeader(New AttributeList({"background-color"}, {"lightblue"}, True))
        TH.AddTableHeaderColumn("Bubble #")
        TH.AddTableHeaderColumn("Feature Name")
        TH.AddTableHeaderColumn("Inspection Method")
        TH.AddTableHeaderColumn("Measured Value")
        TH.AddTableHeaderColumn("In Tolerance?")
        Table.AddTableRow(TH)
        Dim TR As HTMLTable.HTMLTableRow
        
        For i = 0 To 10 Step 1
          'Offset Color
          If i And 1 Then
                'Add Attribute Style to table row with the provided CSS
                TR = New HTMLTable.HTMLTableRow(New AttributeList({"background-color"}, {"lightgray"}, True))
          Else
                TR = New HTMLTable.HTMLTableRow
          End If
          For j = 0 To 5 Step 1
            TR.AddTableColumn(j.ToString)
          Next
          Table.AddTableRow(TR)
        Next
        
        'Add HTML objects to "Report"
        Report.AddToHTMLMarkup(Header)
        Report.AddToHTMLMarkup(Table)
        'Write all HTML markup to specified file (passed in sub)
        File.WriteAllText(FilePath, Report.HTMLMarkup)
    End Sub
End Class
</code></pre>
