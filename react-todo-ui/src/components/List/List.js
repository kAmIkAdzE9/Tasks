import React from "react";
import './List.css'
import { Link } from "react-router-dom";

export default function List(props) {

    function onClickHandler() {
        props.listOnClickHandler(props.id);
    }

    return (
        <Link className='list' to={`${props.id}`}><h2>{props.title}</h2><p>({props.count})</p></Link>
    )  
}