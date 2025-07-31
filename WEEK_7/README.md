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
# React: Conditional Rendering, Element Variables, and Preventing Component Rendering

##  Conditional Rendering in React

Conditional rendering in React refers to the process of displaying UI elements or components based on certain conditions. This is similar to how conditions work in JavaScript, using `if`, `else`, `ternary operators`, or logical `&&` operators to decide what to render.

For example:
- Show a login form if the user is not authenticated.
- Show a welcome message if the user is logged in.

React uses regular JavaScript syntax to handle these conditions, allowing for flexibility and control over what appears on the screen.

### Common Techniques:
- **Ternary Operator**: `condition ? <ComponentA /> : <ComponentB />`
- **Logical AND (`&&`)**: `condition && <Component />`
- **If-Else Statements** (inside functions, not directly in JSX)

---
# React Core Concepts – Conditional Rendering, List Rendering, Keys, and map()

##  Various Ways of Conditional Rendering

Conditional rendering in React allows you to render different UI elements based on logic or conditions. It is similar to how conditions work in JavaScript.

1. **if/else Statement**: Use standard JavaScript logic to render elements based on a condition outside JSX.
2. **Ternary Operator**: A concise way to render content:
   - `condition ? <ComponentA /> : <ComponentB />`
3. **Logical AND (`&&`) Operator**: Useful for rendering a component only when a condition is true:
   - `condition && <Component />`
4. **Element Variables**: Store elements in variables and assign them conditionally before returning them in JSX.

These methods help tailor the UI experience based on user actions, login status, permissions, or data availability.

---

##  How to Render Multiple Components

Rendering multiple components in React can be done by placing them together inside a parent element such as a `<div>`, a `<React.Fragment>`, or shorthand `<>...</>`.

This allows React to return more than one element from a component. It is a common practice to render headers, footers, main content, and other parts of the UI together.

---

##  Define List Component

A list component is a reusable React component designed to display a list of items. It takes an array of data and renders each item using the `map()` function.

This helps in organizing and reusing code when rendering collections of data such as user profiles, product lists, or menus.

---

##  Keys in React Applications

Keys in React are unique identifiers used to keep track of list items. They help React determine which items have changed, been added, or removed.

Keys are important for performance and correct behavior during re-renders. A key must be unique and stable. Preferably use a unique ID rather than the index of the array.

---

##  How to Extract Components with Keys

When dealing with lists, it’s best practice to extract each list item into its own component and pass the `key` as a prop. This enhances modularity and clarity.

React uses the `key` to identify which items need to be updated, added, or removed when the data changes. This extraction pattern is useful when each item has more structure or complexity.

---

##  React Map and `map()` Function

The `map()` function is a built-in JavaScript method that returns a new array by applying a function to each element of an existing array.

In React, `map()` is used to transform an array of data into an array of JSX elements. This is the foundation for dynamically rendering lists based on data.

For example, converting an array of strings into a list of `<li>` elements is done using `map()`.

React will render the resulting array of JSX elements efficiently and accurately.

##  Element Variables

Element variables in React are used to store JSX elements in variables, which can then be conditionally rendered.

Instead of using `if...else` or `ternary` directly inside JSX, you can declare a variable and assign it a JSX element based on conditions.

### Example:

```jsx
let button;
if (isLoggedIn) {
  button = <LogoutButton />;
} else {
  button = <LoginButton />;
}
return <div>{button}</div>;

#  React Events & Event Handling (Theory Only)

##  1. React Events

React Events are how React handles user interactions in a web application. These include actions such as mouse clicks, typing in input fields, form submissions, key presses, and more. React provides its own event system that is very similar to the DOM event system but has some key advantages, such as better cross-browser compatibility and performance optimizations.

React events are passed as **SyntheticEvent** objects and are attached using **camelCase** naming conventions (e.g., `onClick`, `onChange`, `onSubmit`).

---

## 2. Event Handlers

Event Handlers are JavaScript functions that are triggered when a particular event occurs in the React component. They define what should happen in response to user interactions.

These functions are typically written inside the component and are passed to event attributes like `onClick`, `onChange`, etc.

In React:
- Event handlers are passed as **function references**.
- You often use **arrow functions** or **class methods** to define them.

---

##  3. Synthetic Events

Synthetic Events are React’s cross-browser wrapper around the browser’s native events. They provide a consistent and normalized interface for handling events across different browsers.

Every React event handler receives a `SyntheticEvent` object which contains the same interface as the browser's native event, including methods like `preventDefault()` and `stopPropagation()`.

Synthetic events pool objects for performance reasons, so event properties might be nullified after the event callback unless explicitly preserved.

---

##  4. React Event Naming Convention

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

