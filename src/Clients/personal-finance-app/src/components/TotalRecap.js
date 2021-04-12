import React from 'react'

export default function TotalRecap() {
    return (
        <div className="Total-recap">
            <div className="Total">
                <h2>Total:</h2>
                <h2 className="Total-money">24000</h2>
            </div>

            <div className="Prev-month">
                <h2>Prev month:</h2>
                <h2 className="Month-percentage">+13%</h2>
            </div>
        </div>
    )
}
