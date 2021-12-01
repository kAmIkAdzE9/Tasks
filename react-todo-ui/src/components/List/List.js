import React from "react";
import './List.css'
import { NavLink } from "react-router-dom";

export default function List(props) {
    return (
        <NavLink className='list' to={`/todo-list/${props.id}`}><h2>{props.title}</h2><p>({props.count})</p></NavLink>
    )  
}