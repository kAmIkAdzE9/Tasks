import React from "react";
import './Lists.css'
import List from '../List/List'
import { useSelector } from "react-redux";

export default function Lists() {
    const lists = useSelector(state => state.dashboard.lists);
    return (
        <div className="lists">
            {lists.map(list => <List key={list.id} id={list.id} title={list.title} count={list.countOfNonDoneTasks}/>)}
        </div>
    )  
}