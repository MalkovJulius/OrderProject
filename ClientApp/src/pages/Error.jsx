import React from 'react';

const Error = (error) => {
    return(
        <h1>
            This is error - {error.code}.
            {error.message}
        </h1>
        //TODO: background img about error
    )
}

export default Error;