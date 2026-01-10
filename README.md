<h1 align="center">QR Code Generator</h1>

<p align="center">
  <a href="https://learn.microsoft.com/pt-br/dotnet/"><img alt="DotNet 8" src="https://img.shields.io/badge/.NET-5C2D91?logo=.net&logoColor=white&style=for-the-badge" /></a>
  <a href="https://learn.microsoft.com/pt-br/dotnet/csharp/programming-guide/"><img alt="C#" src="https://img.shields.io/badge/C%23-239120?logo=c-sharp&logoColor=white&style=for-the-badge" /></a>
  <a href="https://www.docker.com/"><img alt="Docker" src="https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white" /></a>
  <a href="LICENSE"><img alt="License: MIT" src="https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge" /></a>
</p>

## 💻 Project

This repository was developed for academic purposes and is based on the backend of an MVP (Minimum Viable Product) application that provides an API to generate QR Codes.

The [QRCoder](https://github.com/codebude/QRCoder) library was used to generate the QR Codes!

## 🚀 Technologies and Tools

This project was developed using the following technologies:

- **Backend:**  
  - `.NET 8.0`
  - `ASP.NET Core WebAPI`
  - `C#`
  - `Docker`
  - `XUnit`

## 📌 Technical Decisions

- I decided to create a simple API focused on generating QR Codes.
- Even with a simple structure, I aimed to apply good development practices.
- The project is organized in a way that makes it easy to extend with new features, such as:
  - Connecting to a database.
  - Adding authentication and access permissions.
  - Generating customized QR Code images.
 
## 💾 Clone Repository

```bash
# Clone the repository
git clone https://github.com/pauloalvesm/dotnet-qr-code-generator-api.git

# Navigate to the project folder
cd src/QrCode.Api

# Restore dependencies
dotnet restore

# Run the project
dotnet run
```

## 🧪 How to Run (Docker)

```bash
# Clone the repository
git clone https://github.com/pauloalvesm/dotnet-qr-code-generator-api.git

# Navigate to the project folder
cd dotnet-qr-code-generator-api

# Run the command to build the image and start the container
docker-compose up --build
```

Once running, access the Swagger UI at: http://localhost:8080/swagger/index.html

## 📫 Example Request

### Generate a QR Code

**POST** `/api/qr-code`

```json
{
  "text": "https://github.com/pauloalvesm"
}
```

The response is a Base64 string representing a PNG image.  
To visualize it, you can use an online tool like [Base64 to Image Converter](https://codebeautify.org/base64-to-image-converter).

## 📷 Screenshot

<p align="center"> <img src="https://github.com/PauloAlves8039/dotnet-qr-code-generator/blob/master/src/QrCode.Api/assets/images/screenshot.png" /></p>

## 👤 Author

**[Paulo Alves](https://github.com/pauloalvesm)**

## 📝 License

This project is licensed under the [MIT License](LICENSE).
