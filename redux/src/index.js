import ReactDOM from "react-dom";
import AppComponent from "./components/AppComponent";
import EmployeeListCount from "./components/EmployeeListCount";

import {loadEmployeeData} from "./actions/employeeActions";

import {thunk} from "redux-thunk";

import { createStore, applyMiddleware } from "redux";
import { Provider } from "react-redux";

import rootReducer from "./reducers/index"

var createStoreWithExtraFeature = applyMiddleware(thunk)(createStore);
var appStore = createStoreWithExtraFeature(rootReducer);

appStore.dispatch(loadEmployeeData())

ReactDOM.render((
    <>
        <Provider store={appStore}>
            <EmployeeListCount></EmployeeListCount>
            <AppComponent></AppComponent>
        </Provider>
    </>
    
), document.getElementById("root"));