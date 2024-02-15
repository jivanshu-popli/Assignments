import { combineReducers } from "redux";

import employeeReducer from "./employeeReducer";
import flightReducer from "./flightReducer";
import hotelReducer from "./hotelReducer";

const rootReducer = combineReducers({
    employees: employeeReducer,
    flights: flightReducer,
    hotels: hotelReducer
})

export default rootReducer;

// Common Object in the Store
// var store = {employee: [], flight: [], hotesl: []}