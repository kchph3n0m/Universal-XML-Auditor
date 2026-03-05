# Universal XML Auditor

![Build Status](https://github.com/kchph3n0m/Universal-XML-Auditor/actions/workflows/build.yml/badge.svg)
![CI Pipeline](https://github.com/kchph3n0m/Universal-XML-Auditor/actions/workflows/ci.yml/badge.svg)

A high-performance .NET 9 utility engineered for validating large-scale XML documents against strict XSD schemas while simultaneously verifying the integrity of associated file system assets. Built for reliability during heavy I/O operations, such as pre-flighting statement PDFs and data payloads for archive ingestion.

## Key Features

* **Memory-Efficient Streaming:** Utilizes `XmlReader` to stream 500MB+ files without exhausting system memory.
* **Deep Disk Auditing:** Employs compiled Regex to automatically detect file paths within XML nodes and validates their physical existence on disk.
* **Thread-Safe Async UI:** Multi-threaded architecture ensures the interface remains fully responsive during deep I/O scans, featuring byte-accurate progress tracking and real-time error logging.
* **Zero-Dependency Deployment:** Distributed via an automated CI/CD pipeline as a single, self-contained `win-x64` executable. 

## Installation & Quick Start

1. Navigate to the **[Releases](../../releases/latest)** page.
2. Download the latest `Universal-XML-Auditor.zip` file.
3. Extract the `.zip` to access the standalone `.exe` (No .NET runtime or installation required).
4. Launch the application, select your target XML and XSD files, and click **Run Audit**.
5. View live schema and missing-file errors, and export the full results to a `.txt` report.

## Architecture & SRE Practices

This project enforces strict continuous integration and continuous deployment (CI/CD) standards. Every push to the `main` branch triggers a GitHub Actions pipeline that:
1. Compiles the application in a pristine Windows environment.
2. Executes an xUnit regression suite validating strict schema hierarchy and file-system failure handling.
3. Automatically compiles and publishes a self-contained executable to the Releases page upon version tagging.

---
**Author:** Kyle Holdstein

<img width="802" height="507" alt="Universal XML Auditor UI" src="https://github.com/user-attachments/assets/6687cdff-f37b-488e-b989-6869151de5cd" />