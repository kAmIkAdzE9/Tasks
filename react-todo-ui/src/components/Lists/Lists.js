import React from "react";
import './Lists.css'
import List from '../List/List'
import Tasks from "../Tasks/Tasks";

export default function Lists(props) {
    return (
        <div className="lists">
            {props.lists.map(list => <List key={list.id} id={list.id} title={list.title} count={list.countOfNonDoneTasks} listOnClickHandler={props.listOnClickHandler}/>)}
        </div>
    )  
}