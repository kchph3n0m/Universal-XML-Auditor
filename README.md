Universal XML Auditor
A high-performance .NET 9 utility for validating large XML logs and verifying associated file system integrity.

Features
Speed: Uses XmlReader for streaming 500MB+ files.

Disk Audit: Automatically detects file paths via Regex and verifies they exist on disk.

Async UI: Multi-threaded design ensures the UI never hangs during deep I/O scans.

Reliable: Byte-accurate progress tracking and real-time error logging (capped at 1k for performance).

Portable: Distributed as a single, self-contained win-x64 executable.

Quick Start
Download the latest .exe from the Releases page.

Select your XML and XSD files.

Run Audit to see live schema and file-missing errors.

Export the full results to a .txt report.

Requirements
Windows 10/11 (x64)

.NET 9 Runtime (included in self-contained builds)

Author
Kyle Holdstein
