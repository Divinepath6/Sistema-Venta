
# 🛒 Sistema de Ventas

![C#](https://img.shields.io/badge/C%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_8-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

Un sistema integral de gestión de ventas, inventario y usuarios. Este proyecto demuestra la aplicación práctica de principios de ingeniería de software, estructurado bajo una arquitectura de N-Capas para garantizar escalabilidad, seguridad y un código limpio de fácil mantenimiento.

---

## 🚀 Acerca del Proyecto

Esta aplicación de escritorio está diseñada para administrar eficientemente los procesos comerciales de un negocio. A través de una interfaz fluida y un backend robusto, el sistema permite llevar un control exacto del inventario, gestionar los accesos de usuarios y generar reportes detallados de las transacciones diarias.

### 🏗️ Arquitectura del Sistema
El proyecto está construido utilizando una **Arquitectura de 4 Capas** para una clara separación de responsabilidades:
1. **Capa Presentación (UI):** Contiene los formularios interactivos y la experiencia del usuario final.
2. **Capa Negocio:** Administra las reglas, validaciones y lógica comercial.
3. **Capa Datos:** Gestiona las conexiones y la ejecución de consultas hacia la base de datos.
4. **Capa Entidad:** Define los modelos y objetos de transferencia de datos (DTOs) que viajan entre las capas.

---

## 🛠️ Stack Tecnológico

* **Lenguaje:** C#
* **Framework:** .NET 8
* **Base de Datos:** SQL Server
* **Patrón Arquitectónico:** N-Capas (CapaPresentacion, CapaNegocio, CapaDatos, CapaEntidad)

---

## 👥 Equipo de Desarrollo y Roles

| Miembro | Rol y Contribuciones |
| :--- | :--- |
| 🎨 **Said Sarmiento** | **Frontend & UI:** Encargado del diseño de la interfaz de usuario, experiencia interactiva y programación de las funcionalidades visuales en la Capa de Presentación. |
| 🗄️ **Lucio Martinez** | **Database Developer:** Responsable de la creación, optimización y despliegue de los Procedimientos Almacenados en SQL Server para asegurar un manejo de datos seguro y eficiente. |
| ⚙️ **Jesús Cervantes** | **Backend & Arquitectura:** Implementación de la lógica central en C# .NET, diseño de la estructura relacional de la base de datos, gestión de cadenas de conexión, pruebas exhaustivas de módulos y corrección de errores (debugging). |

---

## 📸 Módulos del Sistema

<!-- INSTRUCCIONES PARA GITHUB: Sube tus imágenes a una carpeta llamada 'docs' o 'images' en tu repositorio y reemplaza las rutas a continuación -->

### 👥 1. Gestión de Usuarios
Módulo para la administración de credenciales, roles y permisos de acceso al sistema.

<div align="center">
  <img width="1349" height="850" alt="image" src="https://github.com/user-attachments/assets/edd49ac2-c421-48cf-9758-c7f878b85db5" />
</div>

### 📦 2. Catálogo de Productos
Control de inventario, registro de nuevos artículos, categorías y gestión de stock.

<div align="center">
  <img width="1346" height="848" alt="image" src="https://github.com/user-attachments/assets/f74daebe-961d-4a20-bda0-03098aae2a49" />

</div>

### 🛒 3. Punto de Venta
Interfaz principal para registrar transacciones, buscar artículos y procesar el cobro.

<div align="center">
 <img width="1353" height="845" alt="image" src="https://github.com/user-attachments/assets/e7d69e09-ad6b-473e-8b4d-4edbf4cf3a96" />

</div>

### 📊 4. Reportes de Ventas
Generación de informes de ventas filtrados por fechas para la toma de decisiones empresariales.

<div align="center">
 <img width="1352" height="862" alt="image" src="https://github.com/user-attachments/assets/f3ca0fb2-09fd-4d6b-9d1d-2c7ac347e708" />

</div>

---

## ⚙️ Configuración y Despliegue

1. Clona este repositorio: `git clone https://github.com/tu-usuario/tu-repo.git`
2. Ejecuta el script SQL incluido en tu servidor local de SQL Server para crear la base de datos y los procedimientos almacenados.
3. Abre la solución en Visual Studio.
4. Modifica la cadena de conexión en la **CapaDatos / App.config** según las credenciales de tu servidor SQL.
5. Compila y ejecuta el proyecto.
