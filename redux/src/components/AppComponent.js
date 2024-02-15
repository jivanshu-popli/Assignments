import { useState, useEffect } from "react";
import * as actions from "../actions/employeeActions";
import EmployeeInfo from "./EmployeeInfo";

import { connect } from "react-redux";
import Axios from "axios";

function AppComponent(props) {
    
    useEffect(() => {
        Axios.get("http://localhost:3000/employees").then((response) => {
            props.saveEmployeeList(response.data)
        });
    }, []);
    
    function deleteAllEmployees() {
        // Trigger Action to Delete All Employees
    }
    
    function deleteEmployee(empId) {
        Axios.delete("http://localhost:3000/employees/" + empId).then(() => {
            props.deleteEmployees(empId);
            alert("Delete Operation is triggered and is Succesfull");
        })
    }
    
    return (
        <>
            {props.employees.map((employee) => {
                return (
                    <>
                        <EmployeeInfo {...employee} deleteEmployee={deleteEmployee}></EmployeeInfo>
                    </>
                )
            })}
            
            <input type="button" value="Delete All Employee" onClick={deleteAllEmployees} />
        </>
    )
}

function mapStoreToProps(store) {
    return {
        employees: store.employees,
        flights: store.flights
    }
}

const ConnectedComponent = connect(mapStoreToProps, actions)(AppComponent)

export default ConnectedComponent;