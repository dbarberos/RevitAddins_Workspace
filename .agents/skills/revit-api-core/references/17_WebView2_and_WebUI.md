# Skill: Modern Interfaces and Web Integration (WebView2 / Frontend-Backend Bridge)

## 1. Technical Data Sheet and Metadata for the Agent
* **Skill ID:** SKILL-RVT-017
* **Technical Area:** Modern UI / Inter-Process Communication (IPC) / Web Technologies
* **API dependencies:** `Microsoft.Web.WebView2.Core`, `Microsoft.Web.WebView2.Wpf`, `Autodesk.Revit.UI.IExternalEventHandler`
* **Design Patterns:** Bridge Pattern, Message Broker, MVVM (Adapted to IPC)
* **Operational Impact:** Allows you to build rich user interfaces, reuse corporate web components and directly connect the Revit UI with cloud dashboards.

---

## 2. The Architecture of Isolated Processes

When we instantiate WebView2 within a Revit Add-in, the interface rendering engine (HTML/CSS/JS) does not run in `Revit.exe`. It runs in multiple child processes of `msedgewebview2.exe`.

**Golden Rule:** The JavaScript environment (Frontend) is completely blind to the Revit database. The C# environment (Backend) is blind to the DOM of the web page. The only form of communication is asynchronous message passing using JSON serialization.

---

## 3. The Communication Bridge (IPC)

For a button on a web page created in React to build a wall in Revit, the message must cross the process bridge and enter the transactional thread.

### A. From the Frontend (JavaScript) to the Backend (C#)
The browser uses an object natively injected by WebView2 to fire messages.

```javascript
// JS (Frontend): User clicks the "Generate" button
function requestWall(height, levelId) {
    const payload = {
        action: "CREATE_WALL",
        data: { height: height, level: levelId }
    };
    // postMessage sends the JSON to C# asynchronously
    window.chrome.webview.postMessage(JSON.stringify(payload));
}

```

### B. From the Backend (C#) to the Revit API

The Add-in must listen for those messages, deserialize them, and **critically** pass them to an `IExternalEventHandler` (SKILL 11) because WebView2 receives the messages in an interface thread, not in the valid Revit execution context.


[See pattern implementation in: assets/Skill17_Pattern_1.cs]


### C. From Revit (C#) to the Frontend (JavaScript)

Once Revit finishes creating the wall, it needs to prompt the web interface to update a graph or display a success message. C# injects and executes JavaScript dynamically in the browser.


[See pattern implementation in: assets/Skill17_Pattern_2.cs]


---

## 4. Antipattern Matrix vs Robust Code

*Common Antipattern (Blocking API Access from WebView)*


[See pattern implementation in: assets/Skill17_Pattern_3.cs]


*Optimized Pattern (Centralized State Management or Redux-like in C#)*
In advanced AECO projects, the C# side acts as a local REST API. A `MessageBroker` or Router is created that sorts the incoming payloads (`"GET_LEEVELS"`, `"CREATE_ASSET"`, `"SELECT_ELEMENTS"`) and fires the corresponding `ExternalEvents`, returning responses to the WebView2 via `ExecuteScriptAsync`.

---

## 5. Implementation in Dockable Panes

WebView2 especially shines when embedded in the native Revit interface using `IDockablePaneProvider`. This allows you to have a sidebar (similar to the properties palette) that is actually a complete React or Angular web application.


[See pattern implementation in: assets/Skill17_Pattern_4.cs]


---

## 6. Agent Injection Instructions (Prompting Prompt)

*When instructed to design UI architectures using WebView2, strictly implement these engineering guidelines:*
1. **Strict Thread Isolation:** Assume by default that ANY method that responds to WebView2's `WebMessageReceived` event is being executed outside the context of the Revit API. The agent MUST inject the `IExternalEventHandler` pattern for any write operations and should never invoke native Revit objects (such as `doc.GetElement`) directly on that event handler without protecting it.
2. **WebView2 Asynchronous Initialization:** The Microsoft control requires environment initialization before it can load source code. Requiredly inject the `await miWebView.EnsureCoreWebView2Async(null)` call in the initial load loop (e.g. the WPF window's `Loaded` event) before assigning properties to `miWebView.Source` or attempting to execute C# to JS scripts.
3. **Strict Data Contracts (JSON):** Defines exclusive C# classes (`record` or `class`) to serialize/deserialize DTO (Data Transfer Objects) messages that travel between JS and C#. Don't use manual string manipulations or lax generic dictionaries; ensures type-safety on the .NET side.
4. **Cleaning the User Data Environment (UserDataFolder):** WebView2 saves cache and history locally. If the Add-in handles multiple projects, configure the initialization options (`CoreWebView2Environment.CreateAsync`) to point the `UserDataFolder` to a temporary or specific subfolder of the Add-in (`%temp%\MyAddinWebView`), ensuring that data is not corrupted between different Revit sessions.