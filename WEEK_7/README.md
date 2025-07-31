# JavaScript ES6 Concepts

This document outlines key features introduced in ECMAScript 2015 (ES6) and provides explanations of specific concepts including `let`, `const`, `class`, `arrow functions`, and more.

---

## Features of ES6

- **Block Scoped Variables (`let`, `const`)**
- **Arrow Functions** for concise function expressions
- **Classes** and **Inheritance**
- **Template Literals** for easier string interpolation
- **Destructuring Assignment** for arrays and objects
- **Default Parameters** in functions
- **Rest and Spread Operators**
- **Promises** for asynchronous programming
- **Modules** for exporting and importing code
- **`Map` and `Set` Data Structures**

---
# 📘 React Events & Event Handling (Theory Only)

## ✅ 1. React Events

React Events are how React handles user interactions in a web application. These include actions such as mouse clicks, typing in input fields, form submissions, key presses, and more. React provides its own event system that is very similar to the DOM event system but has some key advantages, such as better cross-browser compatibility and performance optimizations.

React events are passed as **SyntheticEvent** objects and are attached using **camelCase** naming conventions (e.g., `onClick`, `onChange`, `onSubmit`).

---

## ✅ 2. Event Handlers

Event Handlers are JavaScript functions that are triggered when a particular event occurs in the React component. They define what should happen in response to user interactions.

These functions are typically written inside the component and are passed to event attributes like `onClick`, `onChange`, etc.

In React:
- Event handlers are passed as **function references**.
- You often use **arrow functions** or **class methods** to define them.

---

## ✅ 3. Synthetic Events

Synthetic Events are React’s cross-browser wrapper around the browser’s native events. They provide a consistent and normalized interface for handling events across different browsers.

Every React event handler receives a `SyntheticEvent` object which contains the same interface as the browser's native event, including methods like `preventDefault()` and `stopPropagation()`.

Synthetic events pool objects for performance reasons, so event properties might be nullified after the event callback unless explicitly preserved.

---

## ✅ 4. React Event Naming Convention

React follows specific naming conventions for handling events:

| Aspect              | Convention in React        |
|---------------------|----------------------------|
| Event names         | CamelCase (e.g., `onClick`) |
| Handler values      | JavaScript functions       |
| Attributes used     | Prefixed with `on`         |

**Key Differences from HTML:**
- In HTML, you might use `onclick="myFunction()"`.
- In React, you use `onClick={myFunction}`.

This convention aligns with JSX and JavaScript syntax and provides better error checking and autocomplete features in development environments.

## JavaScript `let`

- `let` declares a block-scoped local variable.
- Unlike `var`, it is not hoisted to the top of the enclosing function or global scope.
- It can be updated but not redeclared within the same scope.

**Example:**
```js
let count = 10;
count = 20; 
let count = 30; // SyntaxError: Identifier 'count' has already been declared
## Difference Between var and let

| Feature        | var                                | let                              |
|----------------|-------------------------------------|----------------------------------|
| Scope          | Function-scoped                    | Block-scoped                     |
| Redeclaration  | Allowed                            | Not allowed in same scope        |
| Hoisting       | Yes, initialized as undefined      | Yes, but not initialized         |
| Global Object  | Adds to global window object       | Does not add to global object    |

 JavaScript const

- const declares a block-scoped constant variable.
- Must be initialized at the time of declaration.
- Cannot be reassigned, but for objects and arrays, properties/elements can be changed.

