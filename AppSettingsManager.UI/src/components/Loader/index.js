import React from 'react';
import * as S from './styled';

const Loader = () => {
    return (
        <S.Container>
            <div className="lds-ripple"><div></div><div></div></div>
        </S.Container>
    )
};

export default Loader;
