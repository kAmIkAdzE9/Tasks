import React from "react";
import './List.css'

export default function List(props) {
    return (
        <div className="list">
            <h2>{props.title}</h2>
            <p> ({props.count})</p>
        </div>
    )  
}