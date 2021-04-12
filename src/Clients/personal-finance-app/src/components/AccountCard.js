import React from 'react';
import * as V from 'victory';
import { VictoryChart, VictoryArea, VictoryTheme} from 'victory';

export default function AccountCard() {
    return (
        <div className="Account-card">
            <h2 className="Account-name">PayPal</h2>
            <h4 className="Account-trend">+50%</h4>
            <VictoryChart
                theme={VictoryTheme.grayscale}
                width={300}
                height={300}
                animate={{
                    duration: 1000,
                    onLoad: { duration: 1000 }
                  }}>
            <VictoryArea
                style={{ data: { fill: "#00ffbd" } }}
                data={[
                    { x: 1, y: 2 },
                    { x: 2, y: 3 },
                    { x: 3, y: 2 },
                    { x: 4, y: 6 },
                    { x: 5, y: 4 },
                    { x: 6, y: 5},
                    ]}
            />
            </VictoryChart>
        </div>
    )
}
