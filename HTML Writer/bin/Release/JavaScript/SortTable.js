var SortTableClass = {
  Tables: [],
  guid: function () {
    function s4() {
      return Math.floor((1 + Math.random()) * 0x10000)
        .toString(16)
        .substring(1);
    }
    return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
      s4() + '-' + s4() + s4() + s4();
  },
  SortTable: function (HTML) {
    this.HTML = HTML;
    this.Headers = [];
    this.Data = [];
    this.ID = (HTML.id != undefined && HTML.id != "") ? HTML.id : SortTableClass.guid();

    if (HTML.querySelectorAll("tr") != undefined) {
      var trs = HTML.querySelectorAll("tr");
      var ths = 0, tds = 0;
      for (var len = trs.length, n = 0; n < len; n++) {
        if (trs[n].querySelectorAll("th") != undefined && trs[n].querySelectorAll("th").length > 0) {
          this.Headers.push(new SortTableClass.SortTableRow(trs[n], ths, "th", this.ID));
          ths += 1;
        } else if (trs[n].querySelectorAll("td") != undefined && trs[n].querySelectorAll("td").length > 0) {
          this.Data.push(new SortTableClass.SortTableRow(trs[n], tds, "td", this.ID));
          tds += 1;
        }
      }
    }

    this.GetHTML = function () {
      var tbl = document.createElement("table");
      var thd = document.createElement("thead");
      var tbd = document.createElement("tbody");
      if (this.Headers.length > 0) {
        for (var len = this.Headers.length, n = 0; n < len; n++) {
          thd.appendChild(this.Headers[n].GetHTML());
        }
      }
      if (this.Data.length > 0) {
        for (var len = this.Data.length, n = 0; n < len; n++) {
          tbd.appendChild(this.Data[n].GetHTML());
        }
      }
      tbl.appendChild(thd);
      tbl.appendChild(tbd);
      var cnt = 0;
      for (var len = this.Headers.length, n = 0; n < len; n++) {
        cnt += this.Headers[n].Cells.length;
      }
      tbl.setAttribute("data-cols", cnt);
      tbl.setAttribute("data-rows", this.Data.length);
      tbl.id = this.ID;
      if (this.SortColumn != undefined) { tbl.setAttribute("data-sortcol", this.SortColumn); }
      if (this.SortDirection != undefined) { tbl.setAttribute("data-sortdir", this.SortDirection); }

      return tbl;
    }

    this.UpdateTableHTML = function (refTable) {
      this.UpdateTHeadHTML(refTable);
      this.UpdateTBodyHTML(refTable);
      var cnt = 0;
      for (var len = this.Headers.length, n = 0; n < len; n++) {
        cnt += this.Headers[n].Cells.length;
      }
      refTable.setAttribute("data-cols", cnt);
      refTable.setAttribute("data-rows", this.Data.length);
      refTable.id = this.ID;
      if (this.SortColumn != undefined) { refTable.setAttribute("data-sortcol", this.SortColumn); }
      if (this.SortDirection != undefined) { refTable.setAttribute("data-sortdir", this.SortDirection); }
      return refTable;
    }
    this.UpdateTHeadHTML = function (refTable) {
      var thd = document.createElement("thead");
      if (this.Headers.length > 0) {
        for (var len = this.Headers.length, n = 0; n < len; n++) {
          thd.appendChild(this.Headers[n].UpdateHTML());
        }
      }
      refTable.replaceChild(thd, refTable.querySelector("thead"));
      return refTable;
    }
    this.UpdateTBodyHTML = function (refTable) {
      var tbd = document.createElement("tbody");
      if (this.Data.length > 0) {
        for (var len = this.Data.length, n = 0; n < len; n++) {
          tbd.appendChild(this.Data[n].UpdateHTML());
        }
      }
      refTable.replaceChild(tbd, refTable.querySelector("tbody"));
      return refTable;
    }

    this.SortTable = function (row, cell, direction) {
      if (direction == "asc" || direction == "Asc" || direction == "ASC") {
        this.Data.sort(function (a, b) {
          if (isNaN(a.GetValue(cell)) && isNaN(b.GetValue(cell))) {
            return a.GetValue(cell).localeCompare(b.GetValue(cell));
          } else {
            return a.GetValue(cell) - b.GetValue(cell);
          }
        });
      } else {
        this.Data.sort(function (a, b) {
          if (isNaN(a.GetValue(cell)) && isNaN(b.GetValue(cell))) {
            return b.GetValue(cell).localeCompare(a.GetValue(cell));
          } else {
            return b.GetValue(cell) - a.GetValue(cell);
          }
        });
      }
      this.Headers[row].Cells[cell].IsSort = direction;
      this.SortColumn = cell;
      this.SortDirection = direction;
      return this.GetHTML();
    }
    this.RemoveSortReferences = function () {
      for (var len = this.Headers.length, n = 0; n < len; n++) {
        for (var clen = this.Headers[n].Cells.length, m = 0; m < clen; m++) {
          this.Headers[n].Cells[m].IsSort = "";
        }
      }
    }
    SortTableClass.Tables.push(this);
    return this;
  },
  // ***************************************
  // ***************Table Row***************
  // ***************************************
  SortTableRow: function (HTML, Index, Type, TableID) {
    this.Cells = [];
    this.Index = (Index != undefined) ? Index : -1;
    this.Type = (Type != undefined) ? Type : "td";
    this.TableId = TableID;
    this.HTML = HTML;

    if (HTML.querySelectorAll(this.Type) != undefined) {
      var tds = HTML.querySelectorAll(this.Type);
      for (var len = tds.length, n = 0; n < len; n++) {
        this.Cells.push(new SortTableClass.SortTableCell(tds[n], n, this.Index, this.Type, TableID));
      }
    }

    this.GetHTML = function () {
      var tr = document.createElement("tr");
      for (var len = this.Cells.length, n = 0; n < len; n++) {
        var td = this.Cells[n].GetHTML();
        tr.appendChild(td);
      }
      tr.setAttribute("data-row", this.Index);
      tr.setAttribute("data-table", this.TableId);
      return tr;
    }
    this.UpdateHTML = function () {
      this.HTML.setAttribute("data-row", this.Index);
      this.HTML.setAttribute("data-table", this.TableId);
      for (var len = this.Cells.length, n = 0; n < len; n++) {
        this.HTML.replaceChild(this.Cells[n].UpdateHTML(), this.HTML.children[n]);
      }
      return this.HTML;
    }
    this.GetValue = function (idx) {
      if (idx > -1 && idx < this.Cells.length) {
        return this.Cells[idx].Value;
      } else {
        return null;
      }
    }
    return this;
  },
  // ***************************************
  // **************Table Cell**************
  // ***************************************
  SortTableCell: function (HTML, Index, Row, Type, TableID) {
    this.HTML = HTML;
    this.Row = (Row != undefined) ? Row : -1;
    this.Index = (Index != undefined) ? Index : -1;
    this.Type = (Type != undefined) ? Type : "td";
    this.Value = HTML.innerText;
    this.TableId = TableID;
    this.IsSort = "";

    this.GetHTML = function () {
      var td = document.createElement(this.Type);
      td.innerHTML = this.Value;
      td.setAttribute("data-cell", this.Index);
      td.setAttribute("data-row", this.Row);
      td.setAttribute("data-table", this.TableId);
      if (this.Type == "th") { // If this cell is a table header, then add handler for sorting
        td.onclick = SortTableClass.headerClicked;
      }
      return td;
    }
    this.UpdateHTML = function () {
      var td = this.HTML;
      td.setAttribute("data-cell", this.Index);
      td.setAttribute("data-row", this.Row);
      td.setAttribute("data-table", this.TableId);
      if (this.Type == "th") { // If this cell is a table header, then add handler for sorting
        td.onclick = SortTableClass.headerClicked;
      }
      return td;
    }
    return this;
  },
  headerClicked: function (e) {
    var htmlRef = document.getElementById(this.dataset.table);
    var parTable = htmlRef.parentElement;
    var refTable;
    if (SortTableClass.Tables.length > 0) {
      var refTable;
      for (var len = SortTableClass.Tables.length, n = 0; n < len; n++) {
        if (SortTableClass.Tables[n].ID == this.dataset.table) {
          refTable = SortTableClass.Tables[n];
          break;
        }
      }
      if (refTable != undefined) {
        if (refTable.SortColumn != undefined && refTable.SortDirection != undefined) {
          if (refTable.SortColumn == this.dataset.cell) {
            if (refTable.SortDirection == "asc") {
              refTable.SortTable(this.dataset.row, this.dataset.cell, "desc");
            } else {
              refTable.SortTable(this.dataset.row, this.dataset.cell, "asc");
            }
          } else {
            refTable.SortTable(this.dataset.row, this.dataset.cell, "asc");
          }
        } else {
          refTable.SortTable(this.dataset.row, this.dataset.cell, "asc");
        }
        // Now replace the old data with the new data
        refTable.UpdateTBodyHTML(htmlRef);
      } else {
        console.log("Couldn't find reference table from the Tables array");
      }
    } else {
      console.log("No reference tables have been added to the Tables array");
      refTable = new SortTable(htmlRef);
      parTable.removeChild(htmlRef);
      if (htmlRef.hasAttribute("data-sortcol") && htmlRef.hasAttribute("data-sortdir")) {
        if (this.dataset.cell == htmlRef.getAttribute("data-sortcol")) {
          // Perform opposite sort operation
          if (htmlRef.getAttribute("data-sortdir") == "asc" || htmlRef.getAttribute("data-sortdir") == "Asc" || htmlRef.getAttribute("data-sortdir") == "ASC") {
            parTable.appendChild(refTable.SortTable(this.dataset.row, this.dataset.cell, "desc"));
          } else {
            parTable.appendChild(refTable.SortTable(this.dataset.row, this.dataset.cell, "asc"));
          }
        } else {
          // Can perform default sort operation
          parTable.appendChild(refTable.SortTable(this.dataset.row, this.dataset.cell, "asc"));
        }
      } else {
        // Can perform default sort operation
        parTable.appendChild(refTable.SortTable(this.dataset.row, this.dataset.cell, "asc"));
      }
    }
  }
}