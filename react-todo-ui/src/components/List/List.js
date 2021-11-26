import React from "react";
import './List.css'
import { Link } from "react-router-dom";

export default function List(props) {
    return (
        <Link className='list' to={`/todo-list/${props.id}`}><h2>{props.title}</h2><p>({props.count})</p></Link>
    )  
}