# BookStore - online book store

---

**Student**: Яцкевич Д.В.

---

Angular CLI needed to run project. So consider running `npm install -g @angular/cli`, then navigate to the main dir `cd BookStore`

## Development server

Now you can launch a dev server, run `ng serve`. After that you can find your app on `http://localhost:4200/`. The app will automatically reload if you change any of the source files. In fact you have to run `npm start` since it will launch dev server with proxy to backend enabled, otherwise none of the http requests would reach backend due to CORS.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.
