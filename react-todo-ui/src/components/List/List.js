import React from "react";
import Lists from "../Lists/Lists";
import './List.css'

export default function List(props) {

    function onClickHandler() {
        props.listOnClickHandler(props.id);
    }

    return (
        <div className='list' onClick={onClickHandler}>
            <h2>{props.title}</h2>
            <p>({props.count})</p>
        </div>
    )  
}