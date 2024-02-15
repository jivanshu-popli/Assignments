import { connect } from "react-redux";

function EmployeeListCount(props) {
    return (
        <>
            <h1>Employee List is having count: { props.employees.length }</h1>
        </>
    )
}

function mapStoreToProps(store) {
    return {
        employees: store.employees
    }
}

const ConnectedComponent = connect(mapStoreToProps, null)(EmployeeListCount)

export default ConnectedComponent;