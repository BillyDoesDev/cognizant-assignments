using System;

// Step 2: Define abstract base class
abstract class Document {
    public abstract void Open();
}

// Step 3: Concrete document classes
class WordDocument : Document {
    public override void Open() {
        Console.WriteLine("Opening a Word document.");
    }
}

class PdfDocument : Document {
    public override void Open() {
        Console.WriteLine("Opening a PDF document.");
    }
}

class ExcelDocument : Document {
    public override void Open() {
        Console.WriteLine("Opening an Excel document.");
    }
}

// Step 4: Factory abstract class
abstract class DocumentFactory {
    public abstract Document CreateDocument();
}

// Step 4: Concrete factories
class WordDocumentFactory : DocumentFactory {
    public override Document CreateDocument() {
        return new WordDocument();
    }
}

class PdfDocumentFactory : DocumentFactory {
    public override Document CreateDocument() {
        return new PdfDocument();
    }
}

class ExcelDocumentFactory : DocumentFactory {
    public override Document CreateDocument() {
        return new ExcelDocument();
    }
}


// Step 5: Test class
class FactoryMethodDemo {
    public static void Main() {
        DocumentFactory wordFactory = new WordDocumentFactory();
        Document word = wordFactory.CreateDocument();
        word.Open();

        DocumentFactory pdfFactory = new PdfDocumentFactory();
        Document pdf = pdfFactory.CreateDocument();
        pdf.Open();

        DocumentFactory excelFactory = new ExcelDocumentFactory();
        Document excel = excelFactory.CreateDocument();
        excel.Open();
    }
}
