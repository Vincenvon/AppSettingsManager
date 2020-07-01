import React from 'react';
import * as S from './styled';

const ReloadButton = ({ onClick }) => {
    return (
        <S.Button type="button" onClick={onClick}>Reload</S.Button>
    );
};

export default ReloadButton;
