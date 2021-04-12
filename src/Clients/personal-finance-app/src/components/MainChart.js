import React from 'react';
import * as V from 'victory';
import { VictoryChart, VictoryLine, VictoryTheme, VictoryAxis, VictoryLabel, VictoryContainer} from 'victory';

export default function MainChart() {
    return (
        <div>
            <VictoryChart 
                theme={VictoryTheme.grayscale}
                width={1300}
                height={300}
                containerComponent={<VictoryContainer responsive={true}/>}
                >
                <VictoryAxis
                    tickLabelComponent= {
                        <VictoryLabel/>
                    }
                    style={{
                        axis: {
                            stroke: 'white'  //CHANGE COLOR OF X-AXIS
                        },
                        tickLabels: {
                            fill: 'white' //CHANGE COLOR OF X-AXIS LABELS
                        }, 
                        grid: {
                            //stroke: 'white' //CHANGE COLOR OF X-AXIS GRID LINES
                        }
                    }}/>
                  <VictoryAxis
                    dependentAxis
                    tickFormat={(y) => y}
                    style={{
                        axis: {
                            stroke: 'white'  //CHANGE COLOR OF Y-AXIS
                        },
                        tickLabels: {
                            fill: 'white' //CHANGE COLOR OF Y-AXIS LABELS
                        }, 
                        grid: {
                            //stroke: 'white', //CHANGE COLOR OF Y-AXIS GRID LINES
                            //strokeDasharray: '7',
                        }
                        }}
                    />
                <VictoryLine
                    style={{
                        data: { stroke: "#a155ff"},
                        parent: { border: "1px solid #ccc"},
                        grid: {
                            stroke: null
                          }
                    }}
                    animate={{
                        duration: 2000,
                        onLoad: { duration: 1000 }
                      }}
                    data={[
                    { x: 1, y: 2 },
                    { x: 2, y: 3 },
                    { x: 3, y: 5 },
                    { x: 4, y: 4 },
                    { x: 5, y: 4 },
                    { x: 6, y: 4 },
                    { x: 7, y: 4 },
                    { x: 8, y: 4 },
                    { x: 9, y: 4 },
                    ]}
                />
                <VictoryLine
                    style={{
                        data: { stroke: "#00ffbd"},
                        parent: { border: "1px solid #ccc"},
                        grid: {
                            stroke: null
                          }
                    }}
                    animate={{
                        duration: 2000,
                        onLoad: { duration: 1000 }
                      }}
                    data={[
                    { x: 1, y: 2 },
                    { x: 2, y: 6 },
                    { x: 3, y: 5 },
                    { x: 4, y: 9 },
                    { x: 5, y: 4 },
                    { x: 6, y: 4 },
                    { x: 7, y: 2 },
                    { x: 8, y: 4 },
                    { x: 9, y: 8 },
                    ]}
                />
            </VictoryChart>
        </div>
    )
}
